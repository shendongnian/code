       private void BtnLogin_Click(object sender, EventArgs e)
        {
            var newForm = new Form2();
            if (txtbName.Text == "Georgi" && txtbPassword.Text == "123" )
            {
                newForm.Show();
            }
       }
