            if (txt_email.Text.Length > 0)
            {
                if (!rEMail.IsMatch(txt_email.Text))
                {
                    MessageBox.Show("E-Mail expected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_email.SelectAll();
                    e.Cancel = true;
                }
            }
