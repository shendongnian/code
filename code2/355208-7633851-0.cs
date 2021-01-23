    public void SetTBVisible(string name, bool visible)
    {
        string cName = name.ToLower();
        foreach(Control c in this.Controls)
            if (c.Name.ToLower() == cName)
            {
                c.Visible = visible;
                break;
            }
    }
