    do
    {
        string guess = Console.ReadLine();
        int guessedNumber = Convert.ToInt16(guess);
    
        if (guessedNumber != number)
        {
            Console.WriteLine("Try again");
            nOfGuesses++;
        }
        else
        {
            Console.WriteLine("You got it!");
            break;
        }
    } while (nOfGuesses < 3);
