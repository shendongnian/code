    if (string.IsNullOrEmpty(this.Txtacc.Text))
    {
        MessageBox.Show("You have not entered account number, Please Enter it...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    else if (string.IsNullOrEmpty(this.Txtamount.Text))
    {
        MessageBox.Show("You have not entered amount, Please Enter it..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    eise if(!double.TryParse(this.Txtamount.Text, out recoverymoney ))
    {
        MessageBox.Show("You have entered an invalid amount, Please Enter a number..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    acno = Txtacc.Text
