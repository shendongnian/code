        class CountryInfo 
        {
        string shortName //Primary Key - (IL or UK for example)
        int ID //Unique - has no meaning, but needs to be saved
        string longName //(Israel or United Kingdom for example)
        }
    
        class CountryCollection
        {
          Dictionary <int, string> Ids = new Dictionary <int, string> ();
          Dictionary <string, string> shortNames = new Dictionary <string, string> ();
    
         void Add (CountryInfo info)
    {
      Ids.Add (info.ID, info.longName);
      shortnames.Add(info.ID, info.longName);
    }
         //Implement methods what you need
         void getByShortName();// I dont know what to return, I'd love
         void getById();// I might need that
         void getAll();// I dont know what to return, I'd l
        }
