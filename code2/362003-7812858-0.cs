    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ButtonClicked != null)
            ButtonClicked(this, new EventArgs());
    }
