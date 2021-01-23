    public ClientElement this[string key]
    {
         get
         {
               return this.Cast<ClientElement>()
                   .Single(ce=>ce.ClientAbbrev == key);
         }
    }
