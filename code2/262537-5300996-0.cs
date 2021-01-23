    public Class Employee
    {
         public int EmployeeID {get; set;}
         public string FirstName {get; set;}
         public string LastName {get; set;}
         public List<Child> Children {get; set;}
    }
    
    public Class Child
    {
        public int ChildID {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public List<Child> Children {get; set;{
    }
