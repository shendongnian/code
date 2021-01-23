    public bool IsDesignTime
    {
        get
        {
           return (System.Windows.Application.Current == null) || (System.Windows.Application.Current.GetType() == typeof(System.Windows.Application));
        }
    }
