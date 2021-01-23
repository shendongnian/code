	public class Prompt : IDisposable
	{
		private Form prompt { get; set; }
		public string Result { get; }
		public Prompt(string text, string caption)
		{
			Result = ShowDialog(text, caption);
		}
		//use a using statement
		private string ShowDialog(string text, string caption)
		{
			prompt = new Form()
			{
				Width = 500,
				Height = 150,
				FormBorderStyle = FormBorderStyle.FixedDialog,
				Text = caption,
				StartPosition = FormStartPosition.CenterScreen,
				TopMost = true
			};
			Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter };
			TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
			Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
			confirmation.Click += (sender, e) => { prompt.Close(); };
			prompt.Controls.Add(textBox);
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(textLabel);
			prompt.AcceptButton = confirmation;
			return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
		}
		public void Dispose()
		{
            //See Marcus comment
			if (prompt != null) { 
                prompt.Dispose(); 
            }
		}
	}
