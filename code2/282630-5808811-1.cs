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
			return Regex.IsMatch(myTextValue, "your regex string");
		}
