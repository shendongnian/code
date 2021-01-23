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
            ManualResetEvent _stopped1;
            ManualResetEvent _stopped2;
    
            public Form1()
            {
                InitializeComponent();
    
                button1.Text = "Click to start";
                button2.Text = "Click to start";
    
                // Initially stopped
                _stopped1 = new ManualResetEvent(true);
                _stopped2 = new ManualResetEvent(true);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // Test if thread was stopped
                if (_stopped1.WaitOne(0))
                {
                    button1.Text = "Running";
    
                    // No more stopped
                    _stopped1.Reset();
    
                    Thread thread2 = new Thread(new ThreadStart(th1));
                    thread2.Start();
                }
                else
                {
                    button1.Text = "Click to start";
    
                    // Signal stop
                    _stopped1.Set();
                }
    
            }
    
            void th1()
            {
                int a = 0;
                // Test if thread was stopped
                while (!_stopped1.WaitOne(0))
                {
                    label1.Invoke((MethodInvoker)(() => label1.Text = Convert.ToString(a)));
                    Thread.Sleep(50);
                    a++;
                }
            }
    
            void th2()
            {
                int b = 0;
    
                while (!_stopped2.WaitOne(0))
                {
                    label2.Invoke((MethodInvoker)(() => label2.Text = Convert.ToString(b)));
                    Thread.Sleep(5000);
                    b = b + 5;
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                if (_stopped2.WaitOne(0))
                {
                    button2.Text = "Running";
    
                    // No more stopped
                    _stopped2.Reset();
    
                    Thread thread2 = new Thread(new ThreadStart(th2));
    
                    thread2.Start();
                }
                else
                {
                    button2.Text = "Click to start";
    
                    // Signal stop
                    _stopped2.Set();
                }
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
               // Signal stopped both threads
                _stopped1.Set();
                _stopped2.Set();
    
                // Process all queued Invoke requests
                Application.DoEvents();
            }
        }
    }
