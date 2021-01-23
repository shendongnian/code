    [ConfigurationProperty("startTime", IsRequired = false, DefaultValue = "00:00:00")]
    [RegexStringValidator(@"\d{2}:\d{2}:\d{2}")]
    public string StartTime
    {
        get 
        {
            return (string) this["startTime"];
        }
        set
        {
            this["startTime"] = value;
        }
    }
