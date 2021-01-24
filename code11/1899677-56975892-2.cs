    public class WeeklyVW
    {
      [StringLength(5)]
      //or time span
      public string Ws_startTime { get; set; }
      [StringLength(5)]
      public string Ws_EndTime { get; set; }
    	
      [Required]
      [DataType(DataType.Time)]
      [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH}")]
      public string Starthour {get;set;}
    }
