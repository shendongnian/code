    class Wrapper
    {
      public string UserFriendly{get;set;}
      public string Technical{get;set;}
    }
    
    var data = new[]
    {
        new Wrapper("Car", "MachineClass"),
        new Wrapper("Plane", "FlyClass"),
    };
    
    combo.Datasource = data;
    combo.DisplayMember = "UserFriendly";
    combo.ValueMember = "Technical";
