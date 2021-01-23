    private void pictureBox94_Click(object sender, EventArgs e)
    {
        if (!checkBox3.Checked)
        {
            pictureBox94.Image = Properties.Resources.select;
        }
        else
        {
            pictureBox94.Image = Properties.Resources.vuoto;
        }
        checkBox3.Checked = !checkBox3.Checked;
    }
