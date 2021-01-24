        if (txt_password.Text == txt_confirm_password.Text)
        {
                    allUsers.Add(new User(txt_fname.Text, txt_lname.Text, 
                    txt_username.Text, txt_password.Text));
                    log_in_form login= new log_in_form(this, allUsers,createdUser);
                    login.Show();
                    this.Hide();
        }
        public log_in_form(sign_up_form par, ArrayList _allUsers,Users newUser)
        {
            InitializeComponent();
            this.formParent = par;
            this.allUsers = _allUsers;
            cmb_user1.DataSource = allUsers;
            cmb_user1.Items.Add(newUser);
        }
