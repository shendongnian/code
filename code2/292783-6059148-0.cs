        static void Main(string[] args)
        {
            var s = "IAmAString-00001";
            int index = -1;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                Console.WriteLine("digits not found");
            else
                Console.WriteLine("digits: {0}", s.Substring(index));
        }
