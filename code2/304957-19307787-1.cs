    namespace TagInput
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
                this.TagInputContainer = new System.Windows.Forms.Panel();
                this.SuspendLayout();
                // 
                // TagInputContainer
                // 
                this.TagInputContainer.Cursor = System.Windows.Forms.Cursors.IBeam;
                this.TagInputContainer.Location = new System.Drawing.Point(157, 161);
                this.TagInputContainer.Name = "TagInputContainer";
                this.TagInputContainer.Size = new System.Drawing.Size(406, 30);
                this.TagInputContainer.TabIndex = 0;
                this.TagInputContainer.Click += new System.EventHandler(this.TagInputContainer_Click);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(664, 395);
                this.Controls.Add(this.TagInputContainer);
                this.Name = "Form1";
                this.Text = "Form1";
                this.ResumeLayout(false);
    
            }
    
            #endregion
    
            private System.Windows.Forms.Panel TagInputContainer;
        }
    }
