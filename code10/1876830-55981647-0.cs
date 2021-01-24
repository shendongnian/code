    public class Account
        {
            public string Email { get; set; }
            public bool Active { get; set; }
            public DateTime CreatedDate { get; set; }
            public IList<Roles> Roles { get; set; }
        }
        public class Roles
        {
            public Dictionary<string, string> User { get; set; }
        }
    static void Main(string[] args)
            {
        Account account = new Account
                {
                    Email = "james@example.com",
                    Active = true,
                    CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                    Roles = new List<Roles> { new Roles { User=new Dictionary<string, string>
                                                {
                        {"Key","value" },
                        {"key","value" }
                                                }
                    },
                    },
                };
                    string json=JsonConvert.SerializeObject(account,Newtonsoft.Json.Formatting.Indented);
                Console.WriteLine(json);
                Console.ReadLine();
        
    }
