    public List<Event> Events 
    {
      get { return (List<Event>)ViewState["EventsList"]; }
      set { ViewState["EventsList"] = value; }
    }
