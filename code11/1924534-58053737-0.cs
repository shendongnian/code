            string[,] rainfallData = new string[5, 2];
            // Load data for 5 days. All the data is stored as string
            for (int dayOfWeek = 0; dayOfWeek < 5; dayOfWeek++)
            {
                Console.WriteLine("Please enter a day of the week: ");
                rainfallData[dayOfWeek, 0] = Console.ReadLine();
                Console.WriteLine($"How many inches of rain did you get on {rainfallData[dayOfWeek, 0]}");
                rainfallData[dayOfWeek, 1] = Console.ReadLine();
            }
            // Now let's find the minimum.
            double minRain = Double.Parse(rainfallData[0, 1]);
            for (int dayOfWeek = 1; dayOfWeek < rainfallData.GetLength(0); dayOfWeek++)
            {
                // you need to convert to double, and then compare.
                double rainOnDayOfWeek = Double.Parse(rainfallData[dayOfWeek, 1]);
                if (rainOnDayOfWeek < minRain)
                {
                    minRain = rainOnDayOfWeek;
                }
            }
            Console.WriteLine($"The day with the lowest amount of rainfall received {minRain} of rain.");
let me know if you don't understand it
