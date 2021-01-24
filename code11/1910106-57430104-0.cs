    private const string yahooEmailIdentifier = "@yahoo.com";
	public bool IsYahoo(string text) => text?.EndsWith(yahooEmailIdentifier, StringComparison.InvariantCultureIgnoreCase) == true;
	public void InsertYahoo(TextBox sender)
	{
		if (!sender.Text.Contains('@'))
		{
			sender.Text = sender.Text + yahooEmailIdentifier;
		}
		else if (!IsYahoo(sender.Text))
		{
			string senderPrefix = sender.Text.Remove(sender.Text.IndexOf('@'));
			sender.Text = senderPrefix + yahooEmailIdentifier;
		}
	}
