	class Form1: Form
	{
		private string str = "hello world hello world hello world";
		private int x = 32, yLabel = 0, yDraw = 64, yRenderer = 32;
		public Form1()
		{
			Font = new Font("Times", 16);
			Label label = new Label();
			label.BorderStyle = BorderStyle.FixedSingle;
			label.AutoSize = true;
			label.Text = str;
			label.Location = new Point(x, yLabel);
			Controls.Add(label);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			SizeF a;
			// TextRenderer
			a = TextRenderer.MeasureText(str, Font);
			TextRenderer.DrawText(e.Graphics, str, Font, new Point(x, yRenderer), Color.Pink);
			e.Graphics.DrawRectangle(new Pen(Color.Blue), x, yRenderer, a.Width, a.Height);
			// DrawString
			e.Graphics.DrawString(str, Font, new SolidBrush(Color.Red), x, yDraw);
			a = e.Graphics.MeasureString(str, Font);
			e.Graphics.DrawRectangle(new Pen(Color.Lime), x, yDraw, a.Width, a.Height);
			base.OnPaint(e);
		}
	}
