    public void Label_Init(object sender, EventArgs e)
    {
        var label = (Label)sender;
        label.Text = ((TextBox)Page.FindControl("SomeControl")).Text;
    }
