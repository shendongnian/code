        static void Main(string[] args)
        {
            //Create an instance of the Random class.  We'll use this
            //to generate random numbers.
            Random rnd = new Random();
            //Our list of random positions.
            List<Position> positions = new List<Position>();
            //Create 100 random positions using `Console.WindowWidth` and 
            // `Console.WindowHeight` to pick a random location on the console screen.
            for (int i = 0; i < 100; i++)
            {
                Position tempPosition = new Position();
                tempPosition.X = rnd.Next(Console.WindowWidth);
                tempPosition.Y = rnd.Next(Console.WindowHeight);
                positions.Add(tempPosition);
            }
            //For each of our randomly generated positions
            foreach (Position pos in positions)
            {
                //Move the cursor to that position on the screen
                Console.SetCursorPosition(pos.X, pos.Y);
                //Use the `Random` class again to randomly pick which character
                //to write to the screen.  In this case, each character has about a 
                //50% chance of getting chosen.
                if (rnd.Next(100) >= 50)
                {
                    Console.Write("$");
                }
                else
                {
                    Console.Write("@");
                }
            }
            //This keeps the program from exiting until we press enter.
            Console.ReadLine();
        }
