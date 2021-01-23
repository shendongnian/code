    private void timer1_Tick(object sender, EventArgs e)
    {
        listBox1.Items.Add(Win32.GetIdleTime().ToString());
        if (Win32.GetIdleTime() > 60000) // 1 minute
        {
            textBox1.Text = "SLEEPING NOW";
        }
    }
