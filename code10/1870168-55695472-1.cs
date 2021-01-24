	private void _Name_TextChanged(object sender, EventArgs e)
	{
		label4.Text = string.Empty;
		
		string name = _Name.Text;
		if (Regex.IsMatch(_Name.Text, "^[a-zA-Z]+$") || _Name.Text=="")
		{
			Calculate_Salary.Enabled = true;
		}
		else
		{
			Calculate_Salary.Enabled = false;
			label4.Text = Validator();
		}
	}
