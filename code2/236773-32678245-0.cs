        static void Main(string[] args)
        {
            string inputstring = "stackOverflows";
            charcount(inputstring, inputstring.ToCharArray()[0]);
        }
        public static void charcount(string recstring ,char c )
        {
            if (recstring.Length != 0)
            {
                int count = 0;
                foreach (char c1 in recstring)
                { if (c1==c)
                {
                    count++;
                }
                
                }
                Console.WriteLine(c+"  "+count);
                string tempstring = recstring.Replace(char.ToString(c), "");
                if (tempstring.Length != 0)
                {
                    charcount(tempstring, tempstring.ToCharArray()[0]);
                }
            }
           
        }
