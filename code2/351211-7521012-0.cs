      if (!int.TryParse(Console.ReadLine(),out myCharacter.age)) {
        Console.WriteLine("You didn't enter a number!!!");
      } else if (myCharacter.age <= 17) { 
        Console.WriteLine("I'm sorry {0}, you're too young to enter!",myCharacter.name); 
      }  else { 
        Console.WriteLine("You can enter!"); 
      } 
 
  
