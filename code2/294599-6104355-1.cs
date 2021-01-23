    public static Control FindControlRecursive(this Control Root, string Id)
    {
        if (Root.ID == Id)
            return Root;
    
        foreach (Control Ctl in Root.Controls)
        {
            Control FoundCtl = FindControlRecursive(Ctl, Id);
            if (FoundCtl != null)
                return FoundCtl;
        }
    
        return null;
    }
