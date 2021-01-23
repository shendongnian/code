    protected void Button1_Click(object sender, EventArgs e)
    {
        double annualHours = 0;
        double.TryParse(txtAnnualHours.Text, out annualHours);
        double rate = 0;
        double.TryParse(txtRate.Text, out rate);
        double salary = (annualHours * rate);
        lblSalary.Text = "$" + salary.ToString();
    }
