	namespace ParallelButtons_7208779
	{
		partial class frmMain
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
				this.components = new System.ComponentModel.Container();
				this.statusStrip1 = new System.Windows.Forms.StatusStrip();
				this.tslblRunStatus = new System.Windows.Forms.ToolStripStatusLabel();
				this.tslblFinalStatus = new System.Windows.Forms.ToolStripStatusLabel();
				this.tmrUpdateStatus = new System.Windows.Forms.Timer(this.components);
				this.statusStrip1.SuspendLayout();
				this.SuspendLayout();
				// 
				// statusStrip1
				// 
				this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
					this.tslblRunStatus,
					this.tslblFinalStatus});
				this.statusStrip1.Location = new System.Drawing.Point(0, 208);
				this.statusStrip1.Name = "statusStrip1";
				this.statusStrip1.Size = new System.Drawing.Size(431, 22);
				this.statusStrip1.TabIndex = 0;
				this.statusStrip1.Text = "statusStrip1";
				// 
				// tslblRunStatus
				// 
				this.tslblRunStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
				this.tslblRunStatus.Name = "tslblRunStatus";
				this.tslblRunStatus.Size = new System.Drawing.Size(80, 17);
				this.tslblRunStatus.Text = "Item {0} of {1}";
				// 
				// tslblFinalStatus
				// 
				this.tslblFinalStatus.Name = "tslblFinalStatus";
				this.tslblFinalStatus.Size = new System.Drawing.Size(60, 17);
				this.tslblFinalStatus.Text = "final status";
				// 
				// tmrUpdateStatus
				// 
				this.tmrUpdateStatus.Tick += new System.EventHandler(this.tmrUpdateStatus_Tick);
				// 
				// frmMain
				// 
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(431, 230);
				this.Controls.Add(this.statusStrip1);
				this.Name = "frmMain";
				this.Text = "Background Form Updates - Stack Overflow 7208779";
				this.statusStrip1.ResumeLayout(false);
				this.statusStrip1.PerformLayout();
				this.ResumeLayout(false);
				this.PerformLayout();
			}
			#endregion
			private System.Windows.Forms.StatusStrip statusStrip1;
			private System.Windows.Forms.ToolStripStatusLabel tslblRunStatus;
			private System.Windows.Forms.ToolStripStatusLabel tslblFinalStatus;
			private System.Windows.Forms.Timer tmrUpdateStatus;
		}
	}
