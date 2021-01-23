    public bool TabVisible
    {
        get 
        {
            return tabControl1.Contains(tabPage2);
        }
        set
        { 
            if(value == TabVisible) return;
            if(value)
                tabControl1.TabPages.Add(tabPage2);
            else
                tabControl1.TabPages.Remove(tabPage2);
        }
    }
