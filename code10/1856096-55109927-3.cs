    namespace DesktopApp1
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
                this.myView2 = new DesktopApp1.MyView();
                this.myView1 = new DesktopApp1.MyView();
                this.SuspendLayout();
                // 
                // myView2
                // 
                this.myView2.Location = new System.Drawing.Point(189, 12);
                this.myView2.Name = "myView2";
                this.myView2.Size = new System.Drawing.Size(150, 150);
                this.myView2.TabIndex = 1;
                // 
                // myView1
                // 
                this.myView1.Location = new System.Drawing.Point(9, 12);
                this.myView1.Name = "myView1";
                this.myView1.Size = new System.Drawing.Size(150, 150);
                this.myView1.TabIndex = 0;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(355, 175);
                this.Controls.Add(this.myView2);
                this.Controls.Add(this.myView1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private MyView myView1;
            private MyView myView2;
        }
    }
