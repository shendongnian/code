    private void button1_Click(object sender, EventArgs e)
    {
        if (!checkbox1.Checked && !checkbox2.Checked && !checkbox100.Checked)
        {
            MessageBox.Show("Please select a checkbox.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            checkbox1.Focus();
        }
        else
        {
            Form f4 = new Confirm();
            f4.Show();
            Hide();
         }
    }
