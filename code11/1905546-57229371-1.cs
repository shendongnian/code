            string str = "O:2275000 BF:3060000 D:3260000";
            int index = str.IndexOf("3060000");
            if (index != -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("Not Found");
            }
Or if the problem is stated like that: **you were given a string and you want to extract the numbers out of it**, then you can do it like so:
        List<decimal> findNumbers(string str)
        {
            List<decimal> x = new List<decimal>();
            string tokens = "";
            foreach (char ch in str)
            {
                if (Char.IsNumber(ch))
                {
                    tokens = tokens + ch;
                }
                if (!Char.IsNumber(ch) && !String.IsNullOrEmpty(tokens))
                {
                    decimal num = Convert.ToDecimal(tokens);                    
                    x.Add(Convert.ToDecimal(num));
                    tokens = "";
                }
            }
            if (String.IsNullOrEmpty(tokens))
            {
                x.Add(Convert.ToDecimal(tokens));
            }
            return x;
        }
this function returns the list of numbers avalable in the string.
