    private void button2_EnabledChanged(object sender, EventArgs e)
    {
        if (((Button)sender).Enabled)
        {
           button2.Text = "Button";
        }
        else
        {
           button2.Text = "";
        }
    }
