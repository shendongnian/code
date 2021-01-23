    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index > -1)
			{
				e.DrawBackground();
				e.Graphics.DrawString(comboBox2.Items[e.Index].ToString(), this.Font, Brushes.Black, e.Bounds);
				e.DrawFocusRectangle();
			}
		}
