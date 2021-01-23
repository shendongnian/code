    [NotMapped]
    public List<String> AllowedBars { get; set; }
    
    /// <summary>
    /// Comma seperated list of AllowedBars
    /// </summary>
    public String AllowedBarsList
    {
        get { return String.Join(",", AllowedBars); }
        set { AllowedBars = value.Split(',').ToList(); }
    }
