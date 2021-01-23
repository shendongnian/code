    protected void Submit_Click(object sender, EventArgs e)
		{
			if (Page.IsValid)
			{
				// do stuff
			}
			else
			{
				// do other stuff
			}
		}
		protected void Text_Validate(object source, ServerValidateEventArgs args)
		{
			args.IsValid = true;
    	// I've done each textbox by id, but depending on how many you might want to loop through the controls instead
			if (!IsTextValid(TextBox1.Text))
			{
				args.IsValid = false;
			}
			if (!IsTextValid(TextBox2.Text))
			{
				args.IsValid = false;
			}
		}
		private bool IsTextValid(string myTextValue)
		{
			string myRegexString = @"^[a-zA-Z]*$";
			
			return Regex.IsMatch(myTextValue, myRegexString);
		}
