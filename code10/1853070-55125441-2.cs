        namespace FormTestLib
    {
        partial class ValidatingSplash
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
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidatingSplash));
                this.lblValidating = new System.Windows.Forms.Label();
                this.SuspendLayout();
    
                // 
                // lblValidating
                // 
                this.lblValidating.Anchor = System.Windows.Forms.AnchorStyles.None;
                this.lblValidating.AutoSize = true;
                this.lblValidating.Location = new System.Drawing.Point(58, 45);
                this.lblValidating.Name = "lblValidating";
                this.lblValidating.Size = new System.Drawing.Size(166, 13);
                this.lblValidating.TabIndex = 7;
                this.lblValidating.Text = "Validating cached credentials...";
                // 
                // ValidatingSplash
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(274, 104);
                this.ControlBox = false;
                this.Controls.Add(this.lblValidating);
                this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Name = "ValidatingSplash";
                this.Text = "Validating Credentials";
                this.ResumeLayout(false);
                this.PerformLayout();
            }
    
            #endregion
            private System.Windows.Forms.Label lblValidating;
        }
    }
