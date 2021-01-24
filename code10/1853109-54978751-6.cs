    [Required]
    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Organization Name Not Valid")]
    [JsonProperty("_organization_Name")]
    public string Organization_Name { get; set; }
    [Required]
    [RegularExpression("^/d{1, 2}///d{1,2}///d{4}$")]
    [JsonProperty("_p_Start_Date")]
    public DateTime? p_Start_Date { get; set; }
    [RegularExpression("^/d{1, 2}///d{1,2}///d{4}$")]
    [JsonProperty("_p_End_Date")]
    public DateTime? p_End_Date { get; set; }
    [Required]
    [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Designation Name Not Valid")]     
    [JsonProperty("_designation")]
    public string Designation { get; set; }
