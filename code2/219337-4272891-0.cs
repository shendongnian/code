    private void btnLogIn_OnClick(...)
    {
        if(/* perform credential test here */)
        {
            (new Form1()).Show(); // create and show the other form
            this.Close(); // close this form
        }
        else
            MessageBox.Show("Login invalid!");
    }
