        static void Main()
        {        
            string input = "hello";
            string output = "";
            int ranIndex = 0;
            List<int> indexes = new List<int>();
            char[] split = input.ToCharArray();
            Random ran = new Random();
            for (int i = 0; i < input.Length; i++) 
            {
                ranIndex = ran.Next(0, input.Length);
                if (!indexes.Contains(ranIndex))
                {
                    indexes.Add(ranIndex);
                }
                else 
                {
                    i--;
                }
            }
            foreach (int value in indexes) 
            {
                output += split[value];
            }
                Console.WriteLine(output);
                Console.ReadLine();
        }
