         bool Valid = False;
        int Number;
        while(Valid == False){
          string Input = Console.Readline();
          if(int.TryParse(Input, out Number){
            Valid = True;
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
            Console.Writeline(“Not an integer, please try again.”)
          }
        }
