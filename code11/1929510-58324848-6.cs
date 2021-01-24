            // Disable/fade gb1 and gb2
            gb1.Enabled = false;
            gb2.Enabled = false;
            // Make gb3 visible
            gb3.Visible = true;
        }
        private void BtnHideGB3_Click(object sender, EventArgs e)
        {
            // Enable/unfade gb1 and gb2
            gb1.Enabled = true;
            gb2.Enabled = true;
            // Hide gb3
            gb3.Visible = false;
        }
