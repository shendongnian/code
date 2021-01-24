    private static void OutputCusipPrice(string filePath)
    {
        using (StreamReader sr = File.OpenText(filePath))
        {
            String s = "", previous ="", price ="";
            bool skipInvalid = false; // This is to remove the negative case
            Regex r = new Regex("^[a-zA-Z0-9]*$");
            int pos = 0;
            while ((s = sr.ReadLine()) != null)
            {
                if(previous != s&& previous != "")
                    Console.WriteLine("Price : " + s);
                if (r.IsMatch(s) && s.Length == 8)
                {
                    Console.WriteLine(s);
                    previous = s;
                    skipInvalid = false;
                }
                else
                {
                    if (skipInvalid) continue;
                    double result;
                    if (Double.TryParse(s, out result))
                    {
                        price = result.ToString(); // cache the previous
                    }
                    else
                    {
                        skipInvalid = true;
                    }
                }
            }
            if(previous != "")
            {
                Console.WriteLine("Price : " + s);
            }
        }
    }
