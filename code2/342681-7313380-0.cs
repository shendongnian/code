    static void Main(string[] args)
    {
        string a = "Are you going to try and change this?";
        string b = "Are you going to try and change this?";
        UsesRefParameter(ref a);
        DoesntUseRefParameter(b);
        Console.WriteLine(a); // I changed the value!
        Console.WriteLine(b); // Are you going to try and change this?
    }
    static void UsesRefParameter(ref string value)
    {
        value = "I changed the value!";
    }
    static void DoesntUseRefParameter(string value)
    {
        value = "I changed the value!";
    }
