        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (sender is Button)
                txtDisplay.Text = txtDisplay.Text + ((Button)sender).Text;
        }
