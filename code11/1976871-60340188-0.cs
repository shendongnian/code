            double numberAsked = 0;
            double yesIcecream = 0, noIcecream = 0, maybeIcecream = 0;
            while (true) // have a nice way to exit in your app
            {
                Console.WriteLine("Do you like Ice cream? ");
                string answer = Console.ReadLine();
                numberAsked++;
                if (answer == "yes")
                {
                    yesIcecream++;
                }
                else if (answer == "no")
                {
                    noIcecream++;
                }
                else if (answer == "maybe")
                {
                    maybeIcecream++;
                }
                
                Console.WriteLine($"yes: { yesIcecream / numberAsked * 100}%");
                Console.WriteLine($"no: { noIcecream / numberAsked * 100 }%");
                Console.Write($"maybe: { maybeIcecream / numberAsked * 100 }%\n\n");
            }
