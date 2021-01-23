    int i = 0;
    private void timer1_Tick(object sender, EventArgs e)
    {
        i++;
        this.Text = i.ToString();
        if (i == 10)
        {
            timer1.Enabled = false;
        }
    }
