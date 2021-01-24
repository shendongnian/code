    public static double ConvertToDouble(string nonConverted)
            {
                double converted;
                while (!double.TryParse(nonConverted, out converted) || String.IsNullOrWhiteSpace(nonConverted))
                {
                    Console.Clear();
                    Console.WriteLine($"INVALID RESPONSE\n\r" +
                        $"\n\rTry Again");
                    nonConverted = Console.ReadLine();
                }
    
                return converted;
            }
