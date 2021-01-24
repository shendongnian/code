         public class UserInfo
        {
            [CSVColumn(ImportName = "FirstName"]
            public string FirstName { get; set; }
    
            [CSVColumn(ImportName = "LastName"]
            public string LastName { get; set; }
    
            [CSVColumn(ImportName = "PhoneNumber"]
            public string PhoneNumber { get; set; }
        }
