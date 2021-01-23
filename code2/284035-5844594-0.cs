    class TheFox
    {
      string _Id;
      string _Name;
      protected TheFox() : this("Default Id", "Default Name"}
      public TheFox(string id, string name) : this()
      {
        _Name = name;
        _Id = id;
      }
      
      public string Id
