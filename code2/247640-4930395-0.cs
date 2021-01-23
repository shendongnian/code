        public static string collatz(string y)
        {
            if (y == null)
            {
                return null;
            }
            int x = int.Parse(y); //x is my "n"
            var results = new StringBuilder();
            results.Append(x.ToString());
            double largest = x; //keep track of biggest number
            // the algorithm
            // the redundancies (like x==1.. x!= 1) are part of troubleshooting :/
            while (x > 1)
            {
                if (x % 2 == 0)
                {
                    x = x / 2;
                    if (x > largest)
                    {
                        largest = x;
                    }
                    if (x != 1)
                    {
                        results.Append(" " + x.ToString());
                    }
                    if (x == 1)
                    {
                        results.Append(" " + x.ToString());
                        results.Append(" largest number was " + largest.ToString());
                        return results.ToString();
                    }
                }
                if (x % 2 != 0)
                {
                    if (x == 1)
                    {
                        results.Append(" " + x.ToString());
                        results.Append(" largest number was " + largest.ToString());
                        return results.ToString();
                    }
                    x = (3 * x) + 1;
                    if (x > largest)
                    {
                        largest = x;
                    }
                    results.Append(" " + x.ToString());
                }
            }
            return results.ToString();
        }
