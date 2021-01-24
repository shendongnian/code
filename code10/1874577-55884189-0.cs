    public string IsDone 
    { 
      get
        {
           if (select) return "Completed";
           return "Pending";
        }
    }
