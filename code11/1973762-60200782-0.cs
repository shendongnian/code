        private static void TestArray()
        {
            string[,] conversionTable = {
                { "Miles to kilometers", "Miles", "Kilometers", "1.6093" },
                { "Kilometers to miles", "Kilometers", "Miles", "0.6214" },
                { "Feet to meters", "Feet", "Meters", "0.3048" },
                { "Meters to feet", "Meters", "Feet", "3.2808" },
                { "Inches to centimeters", "Inches", "Centimeters", "2.54" },
                { "Centimeters to inches", "Centimeters", "Inches", "0.3937" }
            };
            //This loop for filling ComboBox
            for(int i = 0; i < conversionTable.GetLength(0); i++)
            {
                var v = conversionTable[i,0];
                Console.WriteLine(v); //Fill ComboBox
            }
            var selectedIndex = 2; //"Feet to meters"
            Console.WriteLine();
            Console.WriteLine();
            //This loop for displaying values for the selected 
            //... conversion method from the ComboBox
            for(int i = 1; i < conversionTable.GetLength(1); i++)
            {
                Console.WriteLine(conversionTable[selectedIndex,i]);
            }
        }
