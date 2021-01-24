	private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
	{
		Point p = Cursor.Position;
		label1.Text = "x= " + p.X.ToString();
		label2.Text = "y= " + p.Y.ToString();
	}
