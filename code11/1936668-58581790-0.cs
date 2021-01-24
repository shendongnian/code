     public static List<string> answerRange(byte maxTime)
            {
                TimeSpan maxT = new TimeSpan(0, 0, maxTime);
                DateTime initTime = DateTime.Now;
                List<string> userAnswers = new List<string>();
                while ((DateTime.Now - initTime) <= maxT)
                {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKey key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        else
                        {
                            userAnswers.Add(key.ToString());
                        }
                       
                    }
                }
                
                
                return userAnswers;
            }
