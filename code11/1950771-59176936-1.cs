    private void BtnLogin_Click(object sender, EventArgs e)
    {
        var newForm = new Form2();
        if (string.Equals(txtbName.Text, "Georgi") && string.Equals(txtbPassword.Text, "123"))
        {
            newForm.Show();   
            this.Hide(); 
        }
        else
        {
            label2.Text = "Wrong password or username.Try again";
        }
    }
