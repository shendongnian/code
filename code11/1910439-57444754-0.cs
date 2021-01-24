csharp
    private string _a;
which means that it is ONLY accessible by the code in the same class (or struct)
However, you have also defined an accessor/mutator (getter / setter)
csharp
    public string A
    {
        get { return _a; }
        set { _a = value; }
    }
So inside your class2 (incorrect code)
csharp
    public override string ToString()
    {
        return _b + _a; 
    }
you are trying to access a private field, instead of accessing it via the public accessor you have created (corrected code)
csharp
    public override string ToString()
    {
        return _b + A; // note the 'A' (property to access) rather than '_a' (private field)
    }
Alternatively, if you don't want to include the `A` property publically in your base class, you could change the access modifier of _a to be protected, and then it would be accessible in class2 (because it is derived from class1).
