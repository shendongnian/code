            string diceKept;
            do
            {
                Console.WriteLine("Please type the dice number that you would like to keep...and type 'r' to when finished to re-roll remaining dice");
                diceKept = Console.ReadLine();
                if(int.TryParse(diceKept, out var diceNumber))
                {
                    // I am making an assumption here that the user will always input a number between 1-6.
                    // It would be best to put some logic to catch that scenario though.
                    Console.WriteLine(diceEach[diceNumber - 1]);
                }
            } while (diceKept.ToLower() != "r");
            Console.WriteLine("Now re-rolling the rest....");
            // Do some re-relling stuff here.
            Console.Read()
