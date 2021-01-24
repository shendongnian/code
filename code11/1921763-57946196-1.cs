	namespace WindowsFormsApp1
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
				this.button1 = new System.Windows.Forms.Button();
				this.webBrowser1 = new System.Windows.Forms.WebBrowser();
				this.SuspendLayout();
				// 
				// button1
				// 
				this.button1.Location = new System.Drawing.Point(12, 12);
				this.button1.Name = "button1";
				this.button1.Size = new System.Drawing.Size(75, 23);
				this.button1.TabIndex = 0;
				this.button1.Text = "Go";
				this.button1.UseVisualStyleBackColor = true;
				this.button1.Click += new System.EventHandler(this.Button1_Click);
				// 
				// webBrowser1
				// 
				this.webBrowser1.Location = new System.Drawing.Point(11, 66);
				this.webBrowser1.Margin = new System.Windows.Forms.Padding(10);
				this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
				this.webBrowser1.Name = "webBrowser1";
				this.webBrowser1.Size = new System.Drawing.Size(330, 138);
				this.webBrowser1.TabIndex = 1;
				this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1_DocumentCompleted);
				// 
				// Form1
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.AutoSize = true;
				this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
				this.ClientSize = new System.Drawing.Size(475, 222);
				this.Controls.Add(this.webBrowser1);
				this.Controls.Add(this.button1);
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
				this.Name = "Form1";
				this.Text = "Show Get-NetConnectionProfile Output";
				this.ResumeLayout(false);
			}
			#endregion
			private System.Windows.Forms.Button button1;
			private System.Windows.Forms.WebBrowser webBrowser1;
		}
	}
