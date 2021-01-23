    public class MyClass : C
    {
        string B.Property { get; set; }
        string A.Property { get; set; }
        string B { get { return B.Property; } set { B.Property=value; } }
        string A { get { return A.Property; } set { A.Property=value; } }
    }
