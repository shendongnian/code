    if (DB.ValidateUserCredentials(textBox1.Text, textBox2.Text))
    {
        menu mu = new menu(); //can't give a variable the same name as it's type
        mu.Show();
        this.Hide();
    }
    else
    {
        MessageBox.Show("error");
    }
