    private Control FindControlByName(string name)
    {
        foreach (Control c in this.Controls) //assuming this is a Form
        {
            if (c.Name == name)
            return c; //found
        }
        return null; //not found
    }
