    // public string property
    public string string_name { get; set; }
    // within class    
    string_name = "test data";
    MsgBox(string_name); 
    // from another class
    myClassInstance.string_name = "other test data";
