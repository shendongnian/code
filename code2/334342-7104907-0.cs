    private void btnLogIn_Click(object sender, EventArgs e)
    {
        if(ValidateUser())
        {
           //Form1
            DetailForm form = new DetailForm(txtUserName.Text.ToString());
            form.Show();
            //Form2
            Progressbar progress = new Progressbar();
            progress.Show();
            this.Close();
        }
    }
