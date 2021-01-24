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
                this.button2 = new System.Windows.Forms.Button();
                this.panel1.SuspendLayout();
                this.SuspendLayout();
                // 
                // panel1
                // 
                this.panel1.Controls.Add(this.button2);
                this.panel1.Location = new System.Drawing.Point(34, 22);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(701, 383);
                this.panel1.TabIndex = 0;
                this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
               
                // 
                // button2
                // 
                this.button2.Location = new System.Drawing.Point(377, 85);
                this.button2.Name = "button2";
                this.button2.Size = new System.Drawing.Size(75, 23);
                this.button2.TabIndex = 0;
                this.button2.Text = "button2";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Click += new System.EventHandler(this.button2_Click);
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
            
            private System.Windows.Forms.Button button2;
        }
    }
