    //Independent storage, not part of Person class.
    private static List<Person> PersonList = new List<Person>();
    
    static void Main()
    {
        Console.WriteLine("Geef de naam van de persoon: ");
        var name = Console.ReadLine();
        Console.WriteLine("Geef de leeftijd van de persoon: ");
        var age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Geef het geslacht van de persoon [MOET 'v' OF 'm' ZIJN]: ");
        var gender = Console.ReadLine();
    
        //PersonList.Add(new Person("Person1", 25, "M"));
        PersonList.Add(new Person(name, age, gender));
    
        var p = PersonList[0];
        if(p.IsPersonModelStateValid == true)
        {
            Console.WriteLine("Person state is valid");
        }
        else
        {
            Console.WriteLine("Person state is invalid");
        }
        p.PrintPerson();
        Console.Error.WriteLine("Done!");
    }
