    public string Name { get; }
    public Customer(string name)  // Constructor
    {
        Name = name;
    }
    private void SomeFunction()
    {
        Name = "Something Else";  // Compile-time error
    }
