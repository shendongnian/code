    namespace FlashyButton
    {
        partial class FlashyButton
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
            #region Component Designer generated code
            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.lblText = new System.Windows.Forms.Label();
                this.tmrRedraw = new System.Windows.Forms.Timer(this.components);
                this.SuspendLayout();
                // 
                // lblText
                // 
                this.lblText.AutoSize = true;
                this.lblText.Location = new System.Drawing.Point(4, 4);
                this.lblText.Name = "lblText";
                this.lblText.Size = new System.Drawing.Size(55, 17);
                this.lblText.TabIndex = 0;
                this.lblText.Text = "Sample";
                // 
                // tmrRedraw
                // 
                this.tmrRedraw.Interval = 10;
                this.tmrRedraw.Tick += new System.EventHandler(this.tmrRedraw_Tick);
                // 
                // FlashyButton
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.AutoSize = true;
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.Controls.Add(this.lblText);
                this.Name = "FlashyButton";
                this.Size = new System.Drawing.Size(148, 148);
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            #endregion
            private System.Windows.Forms.Label lblText;
            private System.Windows.Forms.Timer tmrRedraw;
        }
    }
