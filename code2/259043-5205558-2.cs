    protected YourType PropertyName
    {
      get 
      {
        if(Session["Sessionname"] != null)
        {
          return Session["Sessionname"] as YourType;
        }
        YourType newItem = new YourType();
        // set vars
        Session["Sessionname"] = newItem;
        return newItem;
      }
      set
      {
       Session["Sessionname"] = value;
      }
    }
