    using System.Drawing;
    
    namespace WindowsFormsApp2
    {
        partial class Form1
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
    
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.panel1 = new System.Windows.Forms.Panel();
              
                this.panel1.SuspendLayout();
                this.SuspendLayout();
                // 
                // panel1
                // 
                
                this.panel1.Location = new System.Drawing.Point(89, 63);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(646, 342);
                this.panel1.TabIndex = 0;
                this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
                this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
              this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseMove);
    
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(800, 450);
                this.Controls.Add(this.panel1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.panel1.ResumeLayout(false);
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private System.Windows.Forms.Panel panel1;
            
           
        }
    }
    
   
