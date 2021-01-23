    [WebGet(UriTemplate = "")]
    public List<Contact> Get()
    {
        var contacts = new List<Contact>()
            {
                new Contact {ContactId = 1, Name = "Phil Haack"},
                new Contact {ContactId = 2, Name = "HongMei Ge"},
                new Contact {ContactId = 3, Name = "Glenn Block"},
                new Contact {ContactId = 4, Name = "Howard Dierking"},
                new Contact {ContactId = 5, Name = "Jeff Handley"},
                new Contact {ContactId = 6, Name = "Yavor Georgiev"}
            };
        return contacts;
    }
