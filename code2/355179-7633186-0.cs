    static void Main(string[] args)
    {
        DateTime birthDateP3 = new DateTime(1980, 2, 25);
        Person p3 = new Person("Ann Person", birthDateP3, 8);
        DateTime birthDateP2 = new DateTime(1980, 2, 25);
        Person p2 = new Person("Ann Person", birthDateP2, 8);
        DateTime birthDateP1 = new DateTime(1980, 2, 25);
        Person p1 = new Person("Ann Person", birthDateP1, 8);
        ArrayList ar = new ArrayList();
        string name = Console.ReadLine();        
        ar.Add(name);
        Console.WriteLine("Print the original Array");
        foreach (Person pr in ar)
            pr.Show();
    }
