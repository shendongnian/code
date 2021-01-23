        static void Main(string[] args)
        {
            string Name = "He is palying in a ground.";
            char[] characters = Name.ToCharArray();
            StringBuilder sb = new StringBuilder();
            for (int i = Name.Length - 1; i >= 0; --i)
            {
                sb.Append(characters[i]);
            }
            Console.Write(sb.ToString());
            Console.Read();
 }
        }
