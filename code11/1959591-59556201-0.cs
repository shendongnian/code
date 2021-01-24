    do
    {
        string guess = Console.ReadLine();
        int guessedNumber = Convert.ToInt16(guess);
    
        if (number == guessedNnumber)
        {
            Console.WriteLine("You got it!");
            break;
        } else {
            Console.WriteLine("Try again");
        }
    
    } while (++nOfGuesses < 3);
