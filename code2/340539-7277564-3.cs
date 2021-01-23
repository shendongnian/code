        protected void Page_Load(object sender, EventArgs e)
        {
            this.btnRegister.Click += new EventHandler(btnRegister_Click);
        }
        void btnRegister_Click(object sender, EventArgs e)
        {
            this.ViewModel.RegisterPerson(txtFirstName.Text, txtLastName.Text);
            this.lvPersons.DataBind();
        }
