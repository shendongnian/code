        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var newForm = new Form2();
            if (string.Equals(txtbName.Text ,"Georgi") &&string.Equals(txtbPassword.Text, "123" )
            {
                newForm.Show();
            }
       }
