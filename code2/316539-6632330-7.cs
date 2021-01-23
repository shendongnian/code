    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            object _closing1;
            object _closing2;
            volatile bool start_a = false;
            volatile bool start_b = false;
    
            public Form1()
            {
                InitializeComponent();
    
                button1.Text = "Click to start";
                button2.Text = "Click to start";
    
                _closing1 = new object();
                _closing2 = new object();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (start_a == false)
                {
                    button1.Text = "Running";
    
                    start_a = true;
    
                    Thread thread2 = new Thread(new ThreadStart(th1));
                    thread2.Start();
                }
                else
                {
                    button1.Text = "Click to start";
    
                    start_a = false;
                }
    
            }
    
            void th1()
            {
                int a = 0;
                while (true)
                {
                    lock (_closing1)
                    {
                        if (start_a == false)
                            break;
                        label1.BeginInvoke((MethodInvoker)(() => label1.Text = Convert.ToString(a)));
                    }
                    Thread.Sleep(50);
                    a++;
                }
            }
    
            void th2()
            {
                int b = 0;
    
                while (true)
                {
                    lock (_closing2)
                    {
                        if (start_b == false)
                            break;
                        label2.BeginInvoke((MethodInvoker)(() => label2.Text = Convert.ToString(b)));
                    }
                    Thread.Sleep(5000);
                    b = b + 5;
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                if (start_b == false)
                {
                    button2.Text = "Running";
                    start_b = true;
                    Thread thread2 = new Thread(new ThreadStart(th2));
    
                    thread2.Start();
                }
                else
                {
                    button2.Text = "Click to start";
                    start_b = false;
                }
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                lock (_closing1)
                {
                    start_a = false;
    
                    // Clear the message queue now so access on disposed lables is possible.
                    // No more invokes will be queued because 1) start_a = false
                    // 2) t1 is out of the critical section
                    Application.DoEvents();
                }
    
                lock (_closing2)
                {
                    start_b = false;
    
                    // Clear the message queue now so access on disposed lables is possible.
                    // No more invokes will be queued because 1) start_b = false
                    // 2) t2 is out of the critical section
                    Application.DoEvents();
                }
            }
        }
    }
