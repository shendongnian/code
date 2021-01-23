    public int CompareTo(object next)
    {
        SessionInfo nextCase = (SessionInfo)next;
        if(SortColumn == "Duration")
            return (this.Duration.CompareTo(nextCase.Duration));
        else if(SortColumn == "Name")
            return (this.Name.CompareTo(nextCase.Name));
    }
