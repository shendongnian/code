    [JsonPropertyAttribute("version")]
    public int? Version 
    {  
      set 
      {
        if (value == null)
        {
          this.version = 0;
        } else this.version = (int)value;
      }
      get { return this.version; }
    }
