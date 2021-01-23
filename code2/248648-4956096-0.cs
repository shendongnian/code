    <MyControls:Control runat="server" Status="Active" />
    public string StatusString // string! because all values in markup are strings
    {
        set
        {
            EntityStatuses s;
            if (Enum.TryParse(value, out s))
                this.status = s; // local variable
        }
    }
    public EntityStatuses Status
    {
        get { return this.status; }
    }
