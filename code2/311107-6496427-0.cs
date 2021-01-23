       public class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
          }
    
          private void button1_Click(object sender, EventArgs e)
          {
             timer1.Enabled = false;
          }
    
          private void timer1_Tick(object sender, EventArgs e)
          {
             MessageBox.Show("Annoying message");
          }
    
             /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;
    
          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
             this.components = new System.ComponentModel.Container();
             this.timer1 = new System.Windows.Forms.Timer(this.components);
             this.button1 = new System.Windows.Forms.Button();
             this.SuspendLayout();
             // 
             // timer1
             // 
             this.timer1.Enabled = true;
             this.timer1.Interval = 300000;
             this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
             // 
             // button1
             // 
             this.button1.Location = new System.Drawing.Point(89, 49);
             this.button1.Name = "button1";
             this.button1.Size = new System.Drawing.Size(75, 23);
             this.button1.TabIndex = 0;
             this.button1.Text = "stop timer";
             this.button1.UseVisualStyleBackColor = true;
             this.button1.Click += new System.EventHandler(this.button1_Click);
             // 
             // Form1
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(292, 266);
             this.Controls.Add(this.button1);
             this.Name = "Form1";
             this.Text = "Form1";
             this.ResumeLayout(false);
    
          }
    
          #endregion
    
          private System.Windows.Forms.Timer timer1;
          private System.Windows.Forms.Button button1;
     }
