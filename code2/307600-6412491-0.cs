    public static System.Web.UI.Control GetPostBackControl(System.Web.UI.Page page)
    {
        Control control = null;
        string ctrlname = page.Request.Params["__EVENTTARGET"];
        if (ctrlname != null && ctrlname != String.Empty)
        {
            control = page.FindControl(ctrlname);
        }
        // if __EVENTTARGET is null, the control is a button type and we need to 
        // iterate over the form collection to find it
        else
        {
            string ctrlStr = String.Empty;
            Control c = null;
            foreach (string ctl in page.Request.Form)
            {
                // handle ImageButton controls ...
                if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                {
                    ctrlStr = ctl.Substring(0, ctl.Length - 2);
                    c = page.FindControl(ctrlStr);
                }
                else
                {
                    c = page.FindControl(ctl);
                }
                if (c is System.Web.UI.WebControls.Button ||
                            c is System.Web.UI.WebControls.ImageButton)
                {
                    control = c;
                    break;
                }
            }
        }
        return control;
    }
