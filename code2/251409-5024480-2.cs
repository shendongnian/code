    private void button_Click(object sender, EventArgs e)
    {
        if (Object.ReferenceEquals(sender, button1))
        {
            formB.Button1WasClicked();
        }
        else
        {
            formB.Button2WasClicked();
        }
    }
