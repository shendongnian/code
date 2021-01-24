    static void Main(string[] args)
    {
        person personStruct = new person();
        Queue<person> personQueue = new Queue<person>();
        Console.WriteLine("Type a name");
        personStruct.name = Console.ReadLine();
        var personFound = false;
        foreach(var p in personQueue)
        {
            if (p.name == personStruct.name)
            {
                personFound = true;
                Console.WriteLine(p.name);
                Console.WriteLine(p.bday);
                Console.WriteLine(p.age);
                break;
            }
        }
        if (!personFound)
        {
            Console.WriteLine("Doesn't exist!");
        }
    }
