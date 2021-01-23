    string vt = Security.GetString(Page.Request.Params["VT"]);
    if (!string.IsNullOrEmpty(vt))
    {
        string[] valuesToSelect = vt.Split(',');
        foreach (ListItem li in lstContriesVisited1.Items)
        {
            li.Selected = Array.Contains(valuesToSelect, li.Value);
        }
    }
