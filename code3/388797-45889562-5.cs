    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Threading;
    using System.IO;
    using System.Timers;
    using System.Reflection;
    using System.Activities;
    using System.Activities.Statements;
    
    namespace WindowsFormsApplication7
    {
    
    
        public partial class Form1 : Form
        {
            Action y;
            WorkflowApplication HomeCycleWFApp = null;
            AutoResetEvent HomeEvent = null;
            Dictionary<string, object> inArgs = new Dictionary<string, object>();
    
    
            public Form1()
            {
                InitializeComponent();           
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                label1.Text = "";           
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                RunHomeCycle(label1, textBox1.Text);
            }       
    
    
            public void RunHomeCycle(Label lbl, string txt)
            {
                button1.Enabled = false;
                if (!inArgs.ContainsKey("lbl"))
                {
                    inArgs.Add("lbl", lbl);
                }
                if (!inArgs.ContainsKey("txt"))
                {
                    inArgs.Add("txt", txt);
                }
                else
                {
                    inArgs["txt"] = txt;
                }
    
                HomeEvent = new AutoResetEvent(false);
    
                HomeCycleWFApp = new WorkflowApplication(new Activity1(), inArgs);
    
               
                HomeCycleWFApp.Completed = delegate (WorkflowApplicationCompletedEventArgs e)
                {
                    button1.Invoke(y = () => button1.Enabled = true);
                    HomeEvent.Set();
    
    
                };
                HomeCycleWFApp.Run();
            }
            
        }
    }
    
