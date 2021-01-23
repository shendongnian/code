	static class TextBoxExtensions
	{
		public static void EnableTextDrop(this TextBox textBox)
		{
			if(textBox == null) throw new ArgumentNullException("textBox");
			// first, allow drop events to occur
			textBox.AllowDrop = true;
			// handle DragOver to provide visual feedback
			textBox.DragOver += (sender, e) =>
				{
					if(((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) &&
						e.Data.GetDataPresent(typeof(string)))
					{
						e.Effect = DragDropEffects.Copy;
					}
				};
			// handle DragDrop to set text
			textBox.DragDrop += (sender, e) =>
				{
					if(((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) &&
						e.Data.GetDataPresent(typeof(string)))
					{
						((TextBox)sender).Text = (string)e.Data.GetData(typeof(string));
					}
				};
		}
	}
