    private Control getControl(Control root, string pClientID)
    {
        if (root.ClientID == pClientID)
            return root;
        foreach (Control c in root.Controls)
        {
            Control subc= getControl(c, pClientID);
            if (subc != null)
                return subc;
        }
        return null;
    }
