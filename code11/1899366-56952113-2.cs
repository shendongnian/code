    if (string.IsNullOrEmpty(this.Txtacc.Text)) {
      MessageBox.Show("You have not entered account number, Please Enter it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    } else if (!myDbContect.Accounts.Any(a => a.AccountNumber == this.Txtacc.Text)) {
      MessageBox.Show("You have not entered a valid account number, Please Enter it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    } else if (!double.TryParse(Txtamount.Text, out double myrecoverymoney)) {
      MessageBox.Show("The amount value you entered is not parseable to a double.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    // do something with account and myrecoverymoney
