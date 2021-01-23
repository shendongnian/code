    void accept(Interface_Test_Visitor v)
    {
        Console.WriteLine("Accepting visitor.");
        v.Visit(this); // lets invoke it this time
    }
