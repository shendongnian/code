	class Class1 : TextBox
	{
		protected override bool IsInputKey(Keys keyData)
		{
			switch (keyData & Keys.KeyCode)
			{
				case Keys.Tab:
					return true;
			}
			return base.IsInputKey(keyData);
		}
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if (e.KeyChar == '\t' && SelectedText.Contains(Environment.NewLine))
			{
				string start = string.Empty;
				if(SelectionStart > 0)
					start = Text.Substring(0, SelectionStart);
				string exchange = Text.Substring(SelectionStart, SelectionLength);
				string end = string.Empty;
				if(SelectionStart + SelectionLength < Text.Length - 1)
					end = Text.Substring(SelectionStart + SelectionLength);
				Text = start + '\t' + 
					exchange.Replace(Environment.NewLine, Environment.NewLine + "\t") + 
					end;
				e.Handled = true;
			}
			base.OnKeyPress(e);
		}
	}
