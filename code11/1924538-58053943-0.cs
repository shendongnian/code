    string[,] rainfallData = new string[5, 2];
            int b = 0;
            int lowest = 99,highest=0;
            for (int i = 0; i <rainfallData.Length-5; i++)
            {
                for (b = 0; b < 1; b++)
                {
                    
                    if (i != rainfallData.Length)
                    {
                        Console.Write("Please enter a day of the week: ");
                        rainfallData[i, b] = Console.ReadLine();
                        Console.Write("How many inches of rain did you get on {0}: ", rainfallData[i, b]);
                        rainfallData[i, b] = Console.ReadLine();
                    }
                    else
                        break;
                }
            }
            for (int i = 0; i < rainfallData.Length-5; i++)
            {
                for (b = 0; b<1; b++)
                {
                    lowest = Math.Min(lowest, Convert.ToInt32(rainfallData[i, b]));
                    highest = Math.Max(highest, Convert.ToInt32(rainfallData[i, b]));
                }
            }
          
            Console.WriteLine("The day with the lowest amount of rainfall received {0}\" of rain.", lowest);
            Console.WriteLine("The day with the highest amount of rainfall received {0}\" of rain.", highest);
    
