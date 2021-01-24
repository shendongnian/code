    public ShellViewModel()
    {
            
            ProfileColumnRows.Add(new TestClass("testc", "a", "b"));
            ProfileColumnRows.Add(new TestClass("testd", "c", "d"));
    }
    
    
     public List<TestClass> ProfileColumnRows {get;set;} = new List<TestClass>();
