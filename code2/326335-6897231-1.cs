    protected void Button_OnClick(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if(button != null)
        {
           string commandArg = button.CommandArgument;
           //Do Work
        }
    }
