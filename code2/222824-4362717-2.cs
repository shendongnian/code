    [DisplayName("Effective Start Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] 
    [StartDate(DateTime.Now)]
    public DateTime EffectiveStartDate { get; set; }
    [DisplayName("Effective Start Date")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] 
    [EndDate(new DateTime(2011, 9, 24)]
    public DateTime EffectiveEndDate { get; set; }
