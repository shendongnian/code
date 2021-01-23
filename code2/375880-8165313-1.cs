    class FormLogin : Form
        {
            public string UserName
            {
                get { return textBoxUserName.Text; }
                set { textBoxUserName.Text = value; }
            }
    
            public string Password
            {
                get { return textBoxPassword.Text; }
                set { textBoxPassword.Text = value; }
            }
    
            public FormLogin()
            {
                this.Closing += new System.ComponentModel.CancelEventHandler(FormLogin_Closing);
            }
    
            void FormLogin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (this.DialogResult == DialogResult.Cancel) return;
    
                if (!LoginUser(UserName, Password))
                {
                    MessageBox.Show("Username or password is incorrect");
                    e.Cancel = true;
                }
    
            }
    
            bool LoginUser(string userName, string password)
            {
                // check login and password in database for example
    
                return true;
            }
        }
    
        class Form3 :Form
        {
            void LoginButtonClick()
            {
                FormLogin formLogin = new FormLogin();
                formLogin.UserName = "LastUserName";
                //uncomment if you want hide main form
                //this.Hide(); 
                if (formLogin.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show(string.Format("Congratulation! You are logged as {0}", formLogin.UserName));
                }
    
                //this.Show();
            }
        }
