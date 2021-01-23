	internal partial class MyForm : Form
	{
		internal MyForm()
		{
			myCharacters.AddRange(...);
		}
		List<string> myCharacters = new List<string>();
		private void ValidateButton_Click(object sender, EventArgs e)
		{
			if (myCharacters.Contains('?'))
			{
				// Do something
			}
		}
	}
