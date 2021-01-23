    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace WindowsFormsApplication23
    {
        public partial class Form3 : Form
        {
            public Form3()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                Thread thread = new Thread(new ThreadStart(countNumbers));
                thread.IsBackground = true;
                thread.Start();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                Thread thread2 = new Thread(new ThreadStart(countNumbers2));
                thread2.Start();
            }
    
            public void countNumbers()
            {
                try
                {
                    for (int i = 0; i < 60000; i++)
                    {
                       this.Invoke((MethodInvoker)delegate()
                       {
                           lock (this)
                           {
                               label2.Text = "" + i.ToString();
                           }
                       }
                    );
                    }
                }
                catch (Exception e)
                {
    
                }
            }
    
            public void countNumbers2()
            {
                try
                {
                    for (int i = 0; i < 60000; i++)
                    {
                        this.Invoke((MethodInvoker)delegate()
                        {
                            lock (this)
                            {
                                label4.Text = "" + i.ToString();
                            }
                        }
                     );
                    }
                }
                catch (Exception e)
                {
    
                }
            }
    
    
    
            private void label3_Click(object sender, EventArgs e)
            {
    
            }
        }
    }
