    if (string.IsNullOrEmpty(this.Txtacc.Text))
    {
       MessageBox.Show("You have not entered account number, Please Enter it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    } else if (!double.TryParse(Txtaacc.Text, out double myrecoverymoney))
    {
       MessageBox.Show("The value you entered is not parseable to a double.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    // do something with myrecoverymoney
