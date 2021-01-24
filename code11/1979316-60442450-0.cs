    private void btn1_Click(object sender, EventArgs e)
    {
        //assuming default background is not green
        //e.g user clicks button while the button says 'Green', it'll change to green
        if (btn1.Text == "Green") 
        {
            BackColor = Color.Green;
            btn1.Text = "Purple";
        }
        else
        {
            BackColor = Color.Purple;
            btn1.Text = "Green";
        }
    }
