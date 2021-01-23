    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace ProjectDocumentationWorkspace.UI
    {
        public partial class MainForm : Form
        {
            private Dictionary<Timer, Label> dict = new Dictionary<Timer, Label>();
    
            public MainForm()
            {
                InitializeComponent();
            }
    
            private void CreateTimers()
            {
                string input = textBox2.Text;
                int n = Convert.ToInt32(input);
                for (int i = 1; i <= n; i++)
                {
    
                    Timer timer = new Timer();
                    timer.Tick += new EventHandler(timer_Tick);
                    timer.Interval = (1000) * (i);
    
                    Label label = new Label();
                    label.Name = "label" + i;
                    label.Location = new Point(100, 100 + i * 30);
                    label.TabIndex = i;
                    label.Visible = true;
    
                    this.Controls.Add(label);
    
                    dict[timer] = label;
    
                    timer.Enabled = true;
                    timer.Start();
                }
            }
    
            private void timer_Tick(object sender, EventArgs e)
            {
                Timer t = (Timer)sender;
                DateTime current = DateTime.Now;
                dict[t].Text = string.Format("{0:00}:{1:00}:{2:00}", current.Hour, current.Minute, current.Second);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                CreateTimers();
            } 
        }
    }
