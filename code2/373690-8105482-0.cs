    public interface IPerson {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
     
    public static void CastToCLRInterface() {
        dynamic New = new ClayFactory();
     
        var person = New.Person();
        person.FirstName = "Louis";
        person.LastName = "Dejardin";
     
        // Concrete interface implementation gets magically created!
        IPerson lou = person;
     
        // You get intellisense and compile time check here
        Console.WriteLine("{0} {1}", lou.FirstName, lou.LastName);
    }
