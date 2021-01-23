    [JsonPropertyAttribute("version")]
    public int? Version 
    {  
        set 
        {
            this.version = value ?? default(int);
        }
        get
        {
          return this.version;
        }
    }
