    public bool AppSettingsRunStatusMet(string appSettingsCheckStatus)
    {
        return Convert.ToBoolean(appSettingsCheckStatus);
    }
    
    public bool TypeARunStatusMet(string type, string status)
    {
       return (type.Equals("A")  && status.Equals("Complete"))
    }
    
    public bool TypeBRunStatusMet(string type, string status)
    {
       return (
           type.Equals("B") && 
           ( 
                status.Equals("Complete") || 
                status.Equals("Other status") || 
                status.Equals("someother status")
           )
    }
