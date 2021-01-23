    public string MaskedVol
    {
      get 
      { 
        return (Name.IndexOf("SPECIAL", StringComparison.OrdinalIgnoreCase) != -1 ) ? "--" : Name;
      }
    }
