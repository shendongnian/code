    class Country
    {
       public string shortName { get; set; } //Primary Key - (IL or UK for example)
       public int ID { get; set; } //Unique - has no meaning, but needs to be saved
       public string longName { get; set; } //(Israel or United Kingdom for example)
    }
