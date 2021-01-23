        public void IntegerReader()
        {
            string integers = Console.ReadLine();
            string[] split = integers.Split(',');
            int result;
            foreach (string s in split)
            {
                if (!string.IsNullOrEmpty(s.Trim()))
                    if (int.TryParse(s.Trim(), out result))
                        Console.WriteLine(result);
            }
        }
