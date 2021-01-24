    public void Validator()
    {
        Calculate_Salary.Enabled = false;
        label4.Text = "Please enter only alphabetical letters";
    }
    private void _Name_TextChanged(object sender, EventArgs e)
    {
        label4.Text = "";
        Regex pattern = new Regex("/^[A-Za-z]+$/");
        string name = _Name.Text;
        if (pattern.IsMatch(name))
        {
            Calculate_Salary.Enabled = true;
        }
        else
        {
            Validator();
        }
    }
