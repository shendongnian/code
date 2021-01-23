    class UserTag
    {
        public string Permission {get;set;}
        public string Name {get;set;}
    }
    
    ....
    myButton.Tag = new UserTag { Permission="1", Name="Alice" };
    ....
    // Use like this:  ((UserTag)myButton.Tag).Permission
