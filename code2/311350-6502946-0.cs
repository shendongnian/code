    protected bool[] Checks
    {
        get { return (bool[])(ViewState["Checks"] ?? new bool[totalLengthOfDataSource]); }
        set { ViewState["Checks"] = value; }
    }
    
    protected void Checkbox_Checked(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        bool[] checks = Checks;
        checks[(int)GetRowDataKeyValue(sender)] = cb.Checked;
        Checks = checks;
    }
    
    protected void Checkbox_PreRender(object sender, EventArgs e)
    {
        CheckBox cb = (CheckBox)sender;
        bool[] checks = Checks;
        cb.Checked = checks[(int)GetRowDataKeyValue(sender)];
    }
