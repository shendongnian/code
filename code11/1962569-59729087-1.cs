    public AdminBrowsableAttribute(bool browsable)
    {
        if (AppContext.UserCode != "Admin")
        {
            this.browsable = browsable;
        }
    }
