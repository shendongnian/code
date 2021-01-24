	public void Validator()
	{
		Calculate_Salary.Enabled = false;
		label4.Text = "Please enter only alphabetical letters";
	}
	private void _Name_TextChanged(object sender, EventArgs e)
	{
		label4.Text = "";
		string name = _Name.Text;
		if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))
			Calculate_Salary.Enabled = true;
		else
			Validator();
	}
