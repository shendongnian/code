    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1 {
      public partial class Form1 : Form {
         public Form1()     {
             InitializeComponent();
          }
          private void Form1_Activate(object sender, EventArgs e)     {
              MoveCursor ();
          }
          private void Form1_Resize(object sender, EventArgs e)     {
             MoveCursor();
         }
          private void Form1_LocationChanged(object sender, EventArgs e)     {
             MoveCursor();
         }
          private void MoveCursor()
          {
             this.Capture = true;
             System.Windows.Forms.Cursor.Clip = Bounds;
         }
    
        private void InitializeComponent()
        {
             this.textBox1 = new System.Windows.Forms.TextBox();
             this.SuspendLayout();
             this.textBox1.AutoCompleteCustomSource.AddRange(new string[] {"all", "allak", "allo"});
             this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
             this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
             this.textBox1.Location = new System.Drawing.Point(30, 70);
             this.textBox1.Name = "textBox1";
             this.textBox1.Size = new System.Drawing.Size(227, 20);
             this.textBox1.TabIndex = 0;
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(284, 264);
             this.Controls.Add(this.textBox1);
             this.Cursor = System.Windows.Forms.Cursors.No;
             this.Name = "Form1";
             this.Text = "Form1";
             this.Activated += new System.EventHandler(this.Form1_Activate);
             this.Resize += new System.EventHandler(this.Form1_Resize);
             this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
             this.ResumeLayout(false);
             this.PerformLayout();
          }
          protected override void Dispose(bool disposing)
          {
             if (disposing && (components != null))
                components.Dispose();
             base.Dispose(disposing);
          }
          private System.ComponentModel.IContainer components = null;
    
          private System.Windows.Forms.TextBox textBox1 = null;
       }
    }
     
