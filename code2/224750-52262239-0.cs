    public DateTime GetDate()
    { 
      var date = context.client.Select(c => DateTime.Now).First(); 
      return date;
    }
