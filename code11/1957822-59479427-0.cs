    public class Response
    		{
    			[JsonProperty("results")] public TimeSheetResponse TimeSheetResponse { get; set; }
    
    			[JsonProperty("more")] public bool More { get; set; }
    		}
    
    		public class TimeSheetResponse
    		{
    			[JsonProperty("timesheets")] public Dictionary<string, Timesheet> Timesheets { get; set; }
    		}
    
    		public class Timesheet
    		{
    			[JsonProperty("id")]
    			public long Id { get; set; }
    
    			[JsonProperty("user_id")]
    			public long UserId { get; set; }
    
    			[JsonProperty("jobcode_id")]
    			public long JobcodeId { get; set; }
    
    			[JsonProperty("start")] public DateTimeOffset Start { get; set; }
    
    			[JsonProperty("end")] public DateTimeOffset End { get; set; }
    
    			[JsonProperty("duration")] public long Duration { get; set; }
    
    			[JsonProperty("date")] public DateTimeOffset Date { get; set; }
    
    			[JsonProperty("tz")] public long Tz { get; set; }
    
    			[JsonProperty("tz_str")] public string TzStr { get; set; }
    
    			[JsonProperty("type")] public string Type { get; set; }
    
    			[JsonProperty("location")] public string Location { get; set; }
    
    			[JsonProperty("on_the_clock")] public bool OnTheClock { get; set; }
    
    			[JsonProperty("locked")] public long Locked { get; set; }
    
    			[JsonProperty("notes")] public string Notes { get; set; }
    
    			[JsonProperty("customfields")] public Dictionary<string, string> Customfields { get; set; }
    
    			[JsonProperty("last_modified")] public DateTimeOffset LastModified { get; set; }
    
    			[JsonProperty("attached_files")] public List<object> AttachedFiles { get; set; }
    
    			[JsonProperty("created_by_user_id")]
    			public long CreatedByUserId { get; set; }
    		}
