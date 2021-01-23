     private void cmdLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "admin" || txtPassword.Text == "1")
            {
                FrmMDI mdi = new FrmMDI();
                mdi.Show();
                this.Hide();
            }
            else {
                MessageBox.Show("Incorrect Credentials", "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
