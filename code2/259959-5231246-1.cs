    private void Checkbox_Click(object sender, EventArgs e)
            {
                if ((sender as CheckBox).Checked)
                {
                    MessageBox.Show("checked");
                    // add role to user
                }
                else
                {
                    MessageBox.Show("un_checked");
                    /remove role ffrom user
                }
            }
