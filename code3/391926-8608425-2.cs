    bool[] desc = new bool[14];
    bool[] local = new bool[14];
    bool[] other = new bool[14];
    for (int i = 1; i <= 14; i++)
    {
        desc[i] = ((CheckBox)Page.FindControl("chkDesc" + i.ToString())).Checked;
        local[i] = ((CheckBox)Page.FindControl("chkLocal" + i.ToString())).Checked;
        other[i] = ((CheckBox)Page.FindControl("chkOther" + i.ToString())).Checked;
        /* Do stuff here */
    }
