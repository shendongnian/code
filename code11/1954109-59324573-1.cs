     int userWonNumber = -1;
    
                for (int i = 0; i < userGuessNums.Length; i++)
                {
                    if (userGuessNums[i] == randomNumber)
                    {
                        userWonNumber = randomNumber;
                    }
                }
    
                if (userWonNumber == randomNumber)
                {
                    Console.WriteLine("Congrats, you won!");
                }
                else
                {
                    Console.WriteLine("Sorry you lost!");
                }
