	public partial class PreviewDialog : Form
	{
		public PreviewDialog() {
			this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
			this.SuspendLayout();
			// 
			// printPreviewControl1
			// 
			this.printPreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.printPreviewControl1.Location = new System.Drawing.Point(0, 0);
			this.printPreviewControl1.Name = "printPreviewControl1";
			this.printPreviewControl1.Size = new System.Drawing.Size(292, 273);
			this.printPreviewControl1.TabIndex = 0;
			this.printPreviewControl1.Columns = 1;
			this.printPreviewControl1.Zoom = 1.0;
		}
	}
