        class TheFox
        {
          string _Id;
          string _Name;
    
          protected TheFox() : this("Default Id", "Default Name")
    
          public TheFox(string id, string name)
          {
            _Name = name;
            _Id = id;
          }
          
          public string Id
          {
            get { return _Id; }
          }
    
          public string Name
          {
            get { return _Name; }
          }
    }
