    foreach (Control c in Page.Controls)
    {
        TextBox t = c as TextBox;
    
        if (t != null)
        {
            t.Text = "sample text";
        }
    }
