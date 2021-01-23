     var newName = Console.ReadLine();
     var person = new Person();
     while (!person.IsValidName(newName))
     {
         newName = Console.ReadLine();
     }
     person.ChangeName(newName);
