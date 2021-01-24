            double myMin2 = Convert.ToDouble(rainfallData[0, 1]);
            for (int i = 0; i < rainfallData.GetLength(0); i++)
            {
                foreach (double element in rainfallData[i, 1])
                {
                    Console.WriteLine($"Element = '{element}'. In ASCII, '{element}' == '{(char)element}' and myMin2 = '{myMin2}'");
                    if (element < myMin2)
                    {
                        myMin2 = element;
                    }
                }
