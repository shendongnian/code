    static void Main(string[] args)
    {
        if (studentGreeting is Person<Greeting>)
                Console.WriteLine("person is Greeting");
        if (studentWarmGreeting is Person<WarmGreeting>)
                Console.WriteLine("person is WarmGreeting");
        
        // Visual Studio is clever and it will say:
        // "The given expression is never of the provided ('Program.Person') type"
        if (studentWarmGreeting is Person<Greeting>)
                Console.WriteLine("person is Greeting");
    }
