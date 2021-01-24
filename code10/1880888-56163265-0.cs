    public DateTime? ActionDate
        {
        get { return actionDate; }
        set
        {
        if (value.HasValue && value.CompareTo(actionDate)!=0)
            actionDate = value;
       OnPropertyChanged("ActionDate");
        } 
