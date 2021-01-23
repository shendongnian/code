    public class UserSettings 
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
    }
    
    // Assign
    HttpContext.Current.Session["UserSettings"] = 
        new UserSettings() {
            UserName = "Bruno Alexandre",
            UserId = 123,
            Company = "StackOverflow Inc.",
            CompanyId = 321
        };
    
    // retrieval: check for nulls
    UserSettings userSettings = 
        HttpContext.Current.Session["UserSettings"] == null ? null : (UserSettings)HttpContext.Current.Session["UserSettings"];
    
    ...
    
    Save( DateTime.UtcNow, userSettings.UserId );
