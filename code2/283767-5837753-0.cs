        foreach (Control c in myControl.Controls)
        {
            if(c.GetType().Equals(typeof(HtmlGenericControl)) &&
               string.Equals((HtmlGenericControl)c).TagName, "div", StringComparison.OrdinalIgnoreCase)
            {
                //do something
            }
        }
