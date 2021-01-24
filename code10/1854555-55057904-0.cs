     public class Contact {
            public string givenName { get; set; }
            public string surname { get; set; }
            public List<emailAddresses> emailAddresses { get; set; }
            public List<string> businessPhones { get; set; }
        }
        public class emailAddresses {
            public string address { get; set; }
            public string name { get; set; }
        }
