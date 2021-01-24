    private void button_OK_Click(object sender, EventArgs e)
    {
        if (authenticated())
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Incorrect credentials", "Retail POS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
