    do 
    {
      //READING OUT CONSOLE
      string userNumberString = Console.ReadLine();
      //CONVERTING STRING TO INT
	  // here you need to be careful, what if user types "a"?
	  // I suggest reading about int.TryParse :)
      userNumber = int.Parse(userNumberString);
      //uN >= 101 AND uN <= 0
      if (userNumber >= 101 || userNumber <= 0)
        Console.WriteLine("Between 1 and 100, Dummy!");
	  // now we are sure we are in the range
      if (userNumber > searchedNumber)
        Console.WriteLine("To High! /n Try again.");
      else if (userNumber < searchedNumber)
        Console.WriteLine("To Low!  /n Try again.");
      else
        //IF NOTHING IS TRUE uN=sN
        Console.WriteLine("JACKPOT!");
    //LOOPING CONDITION
    } while (userNumber != searchedNumber);
