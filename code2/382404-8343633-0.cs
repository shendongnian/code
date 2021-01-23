    static void Main(string[] args)
        {
            Console.WriteLine("Hi.");
            string eersteAntwoord = String.Empty;
            string begroeting = String.Empty;
            bool stop = false;
            while (!stop)
            {
                eersteAntwoord = Console.ReadLine();
                if (eersteAntwoord.Equals("HI", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("How are you doing?");
                    {
                        begroeting = Console.ReadLine();
                        if (begroeting.Equals("I'M GOOD", StringComparison.InvariantCultureIgnoreCase))
                        {
                            Console.WriteLine("Good");
                        }
                        else if (begroeting == "HI")
                        {
                            Console.WriteLine("You hurt your hand."); // I want it to go from here to the first 
                        }
                    }
                }
                if (eersteAntwoord.Equals("STOP", StringComparison.InvariantCultureIgnoreCase)
                    || begroeting.Equals("STOP", StringComparison.InvariantCultureIgnoreCase))
                        break;
            }
        }
