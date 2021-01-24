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
----EDIT----
It is not easy to explain just writing why your code did not work, here I try:
                // Here a lot of very confusing things are happening:
                // 1. All Strings are an array of characters, so here you are doing: "foreach character in rainfallData[i, 1]"
                // 2. In all programming languages, every character is also a code (number). That is called ASCII code. 
                // because you do "double element" you are asking C# to convert that character into it's code
                // for example, 'a' = 97, 'b' = 98, 'A' = 65, 'B' = 66, '1' = 49, '2' = 50
                foreach (double element in rainfallData[i, 1])
                {
                    if (element < myMin2)
                    {
                        myMin2 = element;
                    }
                }
                // This code is exactly the same as the previous one.
                // Maybe here you understand better what is going on
                foreach (char element in rainfallData[i, 1])
                {
                    // This is not the same as Convert.ToDouble, here you are getting the ASCII code of the char
                    double elementCode = (double)element; 
                    if (element < myMin2)
                    {
                        myMin2 = element;
                    }
                }
