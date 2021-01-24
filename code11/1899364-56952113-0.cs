    if (string.IsNullOrEmpty(this.Txtacc.Text))
    {
       MessageBox.Show("You have not entered account number, Please Enter it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    } else if (!double.TryParse(Txtaacc.Text, out double recoverymoney))
    {
       MessageBox.Show("The value you entered is not passable to a double.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
