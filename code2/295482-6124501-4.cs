    // Bad code! Do not use!
    private string fullName;
    public string this[string firstName]
    {
        get { return fullName; }
        set { fullName = firstName + " " + value; }
    }
    // Sample usage...
    foo["Jon"] = "Skeet";
    string name = foo["Bar"]; // name is now "Jon Skeet"
