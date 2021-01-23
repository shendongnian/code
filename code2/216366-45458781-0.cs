        private void btnsubmit_Click(object sender, EventArgs e)
                {
        
                    if (string.IsNullOrEmpty(txtname.Text))
                    {
                        txtname.Focus();
                        errorProvider1.SetError(txtname, "Please Enter User Name");
                    }
        
                    if (string.IsNullOrEmpty(txtroll.Text)) {
                        txtroll.Focus();
                        errorProvider1.SetError(txtroll, "Please Enter Student Roll NO");
                    }
    }
