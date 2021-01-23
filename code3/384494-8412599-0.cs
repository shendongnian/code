	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				Form2 ctxForm = new Form2();
				ctxForm.Location = this.PointToScreen(e.Location);
				ctxForm.Size = new Size(0, 0);
				ctxForm.ShowDialog();
			}
		}
	}
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
		}
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			//show menu once
			contextMenuStrip1.Show(this, PointToClient(Location));
			contextMenuStrip1.Focus();
			timer1.Enabled = false;
		}
		private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.Close();
		}
	}
