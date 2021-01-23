	public static class TextBoxExtensions
	{
		public static void CorrectHeight(this TextBox txtbox)
		{
			if (txtbox.BorderStyle == BorderStyle.None)
			{
				txtbox.BorderStyle = BorderStyle.FixedSingle;
				var heightWithBorder = txtbox.ClientRectangle.Height;
				txtbox.BorderStyle = BorderStyle.None;
				txtbox.AutoSize = false;
				txtbox.Height = heightWithBorder;
			}
		}
	}
