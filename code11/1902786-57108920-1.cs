        public void Play()
        {
            while (true)
            {
                // We should re-read value after each attempt
                int value = ReadInteger();
                if (value > theNumber)
                {
                    Console.WriteLine("your number is too big");
                } 
                else if (value < theNumber)
                {
                    Console.WriteLine("your number is too big");
                }  
                else
                {
                    Console.WriteLine("you got it");
                    break;
                }
            }
        }
