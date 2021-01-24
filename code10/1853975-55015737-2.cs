     private static void OutputCusipPrice(string filePath)
        {
            using (StreamReader sr = File.OpenText(filePath))
            {
                String row = "", current="",previous = "", price = "";
                bool skipInvalid = false; // This is to remove the negative case
                Regex r = new Regex("^[a-zA-Z0-9]*$");
                int pos = 0;
                while ((row = sr.ReadLine()) != null)
                {
                    if (r.IsMatch(row) && row.Length == 8)
                    {
                        current = row;
                        if (previous == "") previous = current;
                        if (current != previous )
                        {
                            previous = row;
                            Console.WriteLine("Price : " + price);
                        }
                        skipInvalid = false;
                        Console.WriteLine(row);
                    }
                    else
                    {
                        if (skipInvalid) continue;
                        double result;
                        if (Double.TryParse(row, out result))
                        {
                            price = result.ToString(); // cache the previous
                        }
                        else
                        {
                            skipInvalid = true;
                        }
                    }
                }
                if (previous != "")
                {
                    Console.WriteLine("Price : " + price);
                }
            }
        }
