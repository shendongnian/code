      else if(isIntString)
      {
           Console.WriteLine("Your name cannot be made up of numbers");
           isIntString = false; // to prevent going into this block again
           Console.Write("Enter your name: ");
           name = Console.ReadLine();
      }
