// Rizabek Mukanov LAB03 Part II
// It is Windows Forms application which uses textboxes and buttons to accomplish tasks of Laboratory work 3
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab03
{
    public partial class Form1 : Form
    {
        //Constructor of form, which initalizes application.
        public Form1()
        {
            InitializeComponent();
        }

        //Event handler, which is activated when button1 is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            //two integers which is numbers from textboxes, are converted into int. Because textbox send it as string
            int n1 = Convert.ToInt32(textBox1.Text);
            int n2 = Convert.ToInt32(textBox2.Text);

            //Message which displays what was returned by FindGCD function, where two integers from above were sent.
            MessageBox.Show(Convert.ToString(FindGCD(n1, n2)));
        }

        //Method to find Greatest common divisor. Uses formulas from book
        public static int FindGCD(int a, int b)
        {
            if (b == 0) {
                return a;
            }
            else
            {
                return FindGCD(b, a % b);
            }
        }


        // Method is called when button2 is clicked, and just sends values to another method
        public static int FindInverse(int m, int b)
        {
            int a1 = 1;
            int a2 = 0;
            int b1 = 0;
            int b2 = 1;

            return ExtendedEuclid(a1, a2, b1, b2, m, b);
        }

        //Method to find inverse number. Again, formulas were taken from book.
        public static int ExtendedEuclid(int a1, int a2, int a3, int b1, int b2, int b3)
        {
            // Checks if there is any possible inverse
            if (b3 == 0) {
                MessageBox.Show("There is no inverse");
                return 0;
            }
            if (b3 == 1) {
                b3 = FindGCD(a3, b3);
                b2 = b3 - 1 % a3;
                return b2;
            }

            // Quotient var which is ratio of a to b which were entered by user.
            int z = a3 / b3;

            int t1 = a1 - z * b1;
            int t2 = a2 - z * b2;
            int t3 = a3 - z * b3;

            MessageBox.Show(Convert.ToString(ExtendedEuclid(b1, b2, b3, t1, t2, t3)));
            return ExtendedEuclid(b1, b2, b3, t1, t2, t3);
        }

        //button2 click event handler
        private void button2_Click(object sender, EventArgs e)
        {
            int n1 = Convert.ToInt32(textBox3.Text);
            int n2 = Convert.ToInt32(textBox4.Text);

            MessageBox.Show(Convert.ToString(FindInverse(n1, n2)));
        }

        //button3 click event handler
        private void Button3_Click(object sender, EventArgs e)
        {
            //array of chars to parse the string inputted by user
            char[] delimeters = { ' ', ',', 'm', 'd' };
            //array of strings formed from strings after parse
            string[] words = textBox5.Text.Split(delimeters);

            int a = Convert.ToInt32(words[0]);
            int b = Convert.ToInt32(words[2]);
            
            //Calling method
            Compare(a, b);
        }

        // This method takes input of user and checks if first integer is either positive or negative.
        public void Compare(int a, int b)
        {
            //if first integer is negative then add second integer until first one becomes positive
            if (a < 0)
            {
                a = a + b;
                Compare(a, b);
            }
            // if both integers are positive then display message.
            else if (a > 0 && a < b)
            {
                MessageBox.Show(Convert.ToString(a) + "mod" + Convert.ToString(b));
                MessageBox.Show(Convert.ToString(FindGCD(a, b)));
            }
        }
    }
}
