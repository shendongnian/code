	public class MyForm : Form
	{
		private Label label;
		public MyForm()
		{
			KeyPress += new KeyPressEventHandler(Form_KeyPress);
			label = new Label();
			label.Text = "foo";
			label.MouseMove += new MouseEventHandler(label_MouseMove);
			Controls.Add(label);
		}
		private void label_MouseMove(object sender, MouseEventArgs e)
		{
			if (MouseButtons == MouseButtons.Left)
			{
				Point loc = label.Location;
				loc.Offset(e.X, e.Y);
				label.Location = loc;
			}
		}
		private void Form_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == ' ')
			{
				if (label.Text == "foo")
					label.Text = "bar";
				else
					label.Text = "foo";
			}
		}
	}
