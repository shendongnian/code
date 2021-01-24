    while (guess != value) //this stands for not equals to 
            {
                if (value > guess)
                {
                    Console.WriteLine("too high");
                    guess = Convert.ToInt32(Console.ReadLine());
                }
                else if (value < guess)
                {
                    Console.WriteLine("too low");
                    guess = Convert.ToInt32(Console.ReadLine());
                }
                else if (value == guess)
                {
                    Console.WriteLine("bang on the answer was" + value);
                }
                else
                {
                    Console.WriteLine("errrrrrrrrr");
                }
            }   
