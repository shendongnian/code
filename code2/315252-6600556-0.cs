    for (int i=0; i<3; i++)
    {
        Control ctl = FindControlRecursive(Page.Controls, "tbNumber", i.ToString());
        if (ctl != null)
        {
            if (ctl is TextBox)
            {
                TextBoxControl tbc = (TextBox)ctl;
                // Do Something with the control here
            }
        }
    }
    private static Control FindControlRecursive(Control Root, string PrefixId, string PostFix)
    {
        if (Root.ID.StartsWith(PrefixId) && Root.ID.EndsWith(PostFix))
            return Root;
        foreach (Control Ctl in Root.Controls)
        {
            Control FoundCtl = FindControlRecursive(Ctl, PrefixId, PostFix);
            if (FoundCtl != null)
                return FoundCtl;
        }
        return null;
    }
