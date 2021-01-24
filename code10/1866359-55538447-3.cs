    namespace DesktopApp2
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
                this.OutputBox = new System.Windows.Forms.TextBox();
                this.InputBox = new System.Windows.Forms.TextBox();
                this.DebugBox = new System.Windows.Forms.ListBox();
                this.SuspendLayout();
                // 
                // OutputBox
                // 
                this.OutputBox.Location = new System.Drawing.Point(52, 93);
                this.OutputBox.Name = "OutputBox";
                this.OutputBox.ReadOnly = true;
                this.OutputBox.Size = new System.Drawing.Size(650, 22);
                this.OutputBox.TabIndex = 1;
                // 
                // InputBox
                // 
                this.InputBox.Location = new System.Drawing.Point(52, 45);
                this.InputBox.Name = "InputBox";
                this.InputBox.Size = new System.Drawing.Size(650, 22);
                this.InputBox.TabIndex = 2;
                // 
                // DebugBox
                // 
                this.DebugBox.FormattingEnabled = true;
                this.DebugBox.ItemHeight = 16;
                this.DebugBox.Location = new System.Drawing.Point(52, 131);
                this.DebugBox.Name = "DebugBox";
                this.DebugBox.Size = new System.Drawing.Size(650, 308);
                this.DebugBox.TabIndex = 3;
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(716, 450);
                this.Controls.Add(this.DebugBox);
                this.Controls.Add(this.InputBox);
                this.Controls.Add(this.OutputBox);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            #endregion
            private System.Windows.Forms.TextBox OutputBox;
            private System.Windows.Forms.TextBox InputBox;
            private System.Windows.Forms.ListBox DebugBox;
        }
    }
