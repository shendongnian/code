    private void button1_Click(object sender, EventArgs e)
    {
        button2_Click(sender, e); // Bad!
    }
    private void button2_Click(object sender, EventArgs e)
    {
        count += 1;
        label1.Text = Convert.ToString(count);
    }
