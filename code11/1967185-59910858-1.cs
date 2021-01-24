         bool Valid = false;
        int Number;
        while(Valid == false){
          string Input = Console.Readline();
          if(int.TryParse(Input, out Number){
            Valid = true;
      if (Number == number){
        Console.WriteLine("You a Genius boe!!!");
      }
      else if ( Number == (number - 1) ){
        Console.WriteLine("A bit Higher!");
      }
      else if ( Number == (number + 1) ){
        Console.WriteLine("A bit Lower!");
      }
      else{
        Console.WriteLine("U Serious Bruh???");
      }
          }
          else{
            Console.Writeline("Not an integer, please try again.")
          }
        }
