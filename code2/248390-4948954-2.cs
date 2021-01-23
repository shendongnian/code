    // private member -- not a property
    private string name;
    
    /// public method -- not a property
    public void setName(string name) {
       this.name = name;
    }
    
    /// public method -- not a property
    public string getName() {
       return this.name;
    }
    
    // yes it is property structure before .Net 3.0
    private string name;
    public string Name {
       get { return name; }
       set { name = value; }
    }
