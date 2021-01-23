    void Main()
    {
       this.GetType()
         .GetField("name", BindingFlags.NonPublic | BindingFlags.Instance)
         .SetValue(this, "Yes");
       Name.Dump();
    }
    
    private readonly string name="No";
    
    public string Name{get{return name;}}
