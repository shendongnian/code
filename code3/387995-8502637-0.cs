    private void txtF1_KeyUp(object sender, KeyEventArgs e)
        {
            string[] val = txtF1.Text.Split('.');
            if (e.Control && e.KeyCode == Keys.V)
            {
                txtF1.Text = val[0].ToString();
                txtF2.Text = val[1].ToString();
                txtF3.Text = val[2].ToString();
                txtF4.Text = val[3].ToString();
            }
        }
