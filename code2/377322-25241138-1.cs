    [NotMapped]
    public List<String> AllowedBars { get; set; }
    
    /// <summary>
    /// Comma seperated list of AllowedBars
    /// </summary>
    public String AllowedBarsList
    {
        get { return String.Join(",", AllowedBars); }
        set
		{
		    if (String.IsNullOrWhiteSpace(value))
			{
			    AllowedBars.Clear();
			}
			else
		    {
			    AllowedBars = value.Split(',').ToList();
		    }
	    }
    }
