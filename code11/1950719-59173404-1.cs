    private void BtnLogin_Click(object sender, EventArgs e)
    {
       var newForm = new Form2();
       if (string.Equals(txtbName.Text.ToLower() , "Georgi".ToLower()) && string.Equals(txtbPassword.Text , "123"))
        {
          newForm.Show();
        }
    }
