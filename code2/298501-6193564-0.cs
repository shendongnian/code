    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class Form1 : Form
        {
            DateTime keyDownTime;
            DateTime keyUpTime;
            
    
            public Form1()
            {
                this.SuspendLayout();
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Name = "Form1";
                this.Text = "Form1";
                this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
                this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
                this.ResumeLayout(false);
            }
    
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                keyDownTime = DateTime.Now;
            }
    
            private void Form1_KeyUp(object sender, KeyEventArgs e)
            {
                keyUpTime = DateTime.Now;
    
                MessageBox.Show((keyUpTime.Subtract(keyDownTime)).TotalSeconds.ToString());
            }
        }
    }
