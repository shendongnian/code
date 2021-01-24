            values.Add(1.0);
            values.Add(2.0);
            values.Add(2.2);
            values.Add(2.5);
            values.Add(5.0);
            values.Add(5.5);
            string value = ">=2.5";
            if (value.Contains(">="))
            {
                var valueDouble = Convert.ToDouble(value.Replace(">=", "").Trim());//IMPORT THECONVERSION TO DOUBLE!
                double greatestVersion = 0;
                foreach (var item in values)
                {
                    if (item >= valueDouble)
                        greatestVersion = item;
                }
                Console.WriteLine($"The greatest version is " + greatestVersion);
            }
