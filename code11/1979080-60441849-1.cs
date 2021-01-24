    public DateTime SelectedHistoryTime 
    { 
        get { return _SelectedHistoryTime; }
        set
           {
             _SelectedHistoryTime = value;
             NotifyChange("SelectedHistoryTime");
             // These rely on this property, so they change too
             NotifyChange("HistoryTime");
             NotifyChange("Timeframe");
           }
    }
                 
