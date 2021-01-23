    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.Run(new TestForm1());
            }
        }
        public partial class TestForm1 : Form
        {
            private System.Windows.Forms.Button button1;
            public void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Hello! Im TestForm1 and Im going to call TestForm2's code!");
                // You must create TestForm2 because of button1_Click is not a static method!!!
                TestForm2 form2 = new TestForm2();
                form2.button1_Click(this, new EventArgs());
            }
            public TestForm1()
            {
                this.button1 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(12, 12);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(88, 23);
                this.button1.TabIndex = 0;
                this.button1.Text = "button1";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                this.Controls.Add(this.button1);
                this.Name = "TestForm1";
                this.Text = "TestForm1";
                this.ResumeLayout(false);
            }
        }
        public partial class TestForm2 : Form
        {
            private System.Windows.Forms.Button button1;
            public void button1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Hello! Im TestForm2");
            }
            public TestForm2()
            {
                this.button1 = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(12, 12);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(88, 23);
                this.button1.TabIndex = 0;
                this.button1.Text = "button1";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
                this.Controls.Add(this.button1);
                this.Name = "TestForm2";
                this.Text = "TestForm2";
                this.ResumeLayout(false);
            }
        }
    }
