    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var color = Color.FromName((sender as Control).Text);
        if (color.IsKnownColor) {
            pictureBox1.BackColor = color;
        }
        else {
            pictureBox1.BackColor = Color.White;
        }
    }
