    foreach (Control item in Page.Form.FindControl("ContentPlaceHolder1").Controls)
    {
        if (item is TextBox)
        {
            ((TextBox)item).Text = string.Empty;
        }
    }
