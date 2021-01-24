    int inputValue;
    bool repeat = true;
    
    do{
      Console.WriteLine("Please enter first Number");
      string input = Console.ReadLine();
    
      bool validInput = int.TryParse(input, out inputValue);
    
      if(validInput)
        repeat = false;
      else
        Console.WriteLine("Invalid Input. Press any key to try again");
        Console.ReadKey();
    }while(repeat);
