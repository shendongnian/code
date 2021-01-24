    public static void ResetAllControls(Control parent)
    {
        foreach(var child in parent.Controls)
            ResetAllControls(child);
        if(parent is TextBox)
        {
            (parent as TextBox).Text = "";
            return;
        }
        //and so on
    }
