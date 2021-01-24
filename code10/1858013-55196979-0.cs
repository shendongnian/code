    private void bminus_Click(object sender, EventArgs e)
    {
        NUMBER--;
        textBox2.Text = NUMBER.ToString();
        if(NUMBER == 0){
            bminus.Enabled = false;
        }
    }
    private void bplus_Click(object sender, EventArgs e)
    {
        NUMBER++;
        textBox2.Text = NUMBER.ToString();
        bminus.Enabled = true;
    }
