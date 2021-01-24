    public string getActions(bool isView, bool isAddupdate, bool isDelete)
    {
        string[] values = new string[3];
        if (isView)
            values[0] = "0";
        if (isAddupdate)
            values[1] = "1";
        if (isDelete)
            values[2] = "2";
        return String.Join(",", values.Where(s => !string.IsNullOrEmpty(s)));
    }
