    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    
        class Form1 : Form
        {
            private Panel panel1;
            private Button button1;
    
            public Form1()
            {
                this.panel1 = new Panel();
                this.button1 = new Button();
    
                this.SuspendLayout();
    
                this.panel1.Location = new System.Drawing.Point(305, 51);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(457, 338);
                this.panel1.TabIndex = 0;
    
                this.button1.Location = new System.Drawing.Point(321, 9);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 23);
                this.button1.TabIndex = 1;
                this.button1.Text = "button1";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.button1_Click);
    
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.Controls.Add(this.button1);
                this.Controls.Add(this.panel1);
                this.Name = "Form1";
                this.Text = "Form1";
    
                this.ResumeLayout(false);
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 form2 = new Form2();
    
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.TopLevel = false;
                form2.AutoScroll = true;
    
                panel1.Controls.Clear();
                panel1.Controls.Add(form2);
    
                form2.Show();
            }
        }
    
        class Form2 : Form
        {
            private Button button1;
    
            public Form2()
            {
                this.button1 = new Button();
    
                this.SuspendLayout();
    
                this.button1.Location = new System.Drawing.Point(321, 9);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(75, 23);
                this.button1.TabIndex = 1;
                this.button1.Text = "button1";
                this.button1.UseVisualStyleBackColor = true;
    
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = AutoScaleMode.Font;
                this.BackColor = System.Drawing.Color.Yellow;
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.Controls.Add(this.button1);
                this.Name = "Form2";
                this.Text = "Form2";
    
                this.ResumeLayout(false);
    
            }
        }
    }
