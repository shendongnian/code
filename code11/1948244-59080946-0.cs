    #define CONDITION1
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    namespace Test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                Method1();
                Method2();
            }
            // Only execute when defined "CONDITION1"
            [Conditional("CONDITION1")]
            void Method1()
            {
                Console.WriteLine("Method1");
            }
            void Method2()
            {
                Console.WriteLine("Method2");
            }
        }
    }
