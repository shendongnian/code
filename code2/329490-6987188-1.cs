      Private string _fristName;
    
      public string FirstName 
      {
           get { return _fristName ?? String.Empty; }
           set { _fristName= value; }
      }
