    public int SomeProp
    {
      get 
      { 
         var attribs = 
               this.GetType().GetProperty(this.Item(o => o.SomeProp)).Attributes;
      }
    }
