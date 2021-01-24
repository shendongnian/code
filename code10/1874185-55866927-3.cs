       public static double Coefficient()
        {
            while (true)
            {
                string string1 = Console.ReadLine();
                string[] stringArray = string1.Split('^');
                double[] doubleArray = Array.ConvertAll(stringArray, double.Parse);
                if (doubleArray.Length == 2)
                {
                    double coefficient = Math.Pow(doubleArray[0], doubleArray[1]);
                    return coefficient;
                }
                else if (doubleArray.Length == 1)
                {
                    return doubleArray[0];
                }
              Console.WriteLine("Please follow the specified input form (a^b).");
            }
            
        }
