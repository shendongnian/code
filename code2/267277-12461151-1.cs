        private void textBox1_DragOver(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop, true))
			{
				string[] filenames = e.Data.GetData(DataFormats.FileDrop, true) as string[];
				if(filenames.Count() > 1 || !System.IO.Directory.Exists(filenames.First()))
				{
					e.Effects = DragDropEffects.None;
					e.Handled = true;
				}
				else
				{
					e.Handled = true;
					e.Effects = DragDropEffects.Move;
				}
			}
		}
		private void textBox1_Drop(object sender, DragEventArgs e)
		{
			var buffer = e.Data.GetData(DataFormats.FileDrop, false) as string[];
			textBox1.Text = buffer.First();
		}
