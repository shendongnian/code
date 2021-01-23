    public class UserDTO
        {
            public int Id { get; set; }
            public int SourceId { get; set; }
            public string SourceName { get; set; }
    
            [ReportHeaderAttribute("User Type")]
            public string UsereType { get; set; }
    
            [ReportHeaderAttribute("Address")]
            public string Address{ get; set; }
    
            [ReportHeaderAttribute("Age")]
            public int Age{ get; set; }
    
            public bool IsActive { get; set; }
    
            [ReportHeaderAttribute("Active")]
            public string IsActiveString
            {
                get
                {
                    return IsActive ? "Yes" : "No";
                }
            }}
