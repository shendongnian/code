    class Program
    {
        static bool IsPositionfilled(int Position, List<int> WordPositions)
        {
            return WordPositions.Exists(a => a == Position);
        }
        public static string shufflestring(string word)
        {
            List<int> WordPositions = new List<int>();
            Random r = new Random();
            string shuffledstring = null;
            foreach (char c in word)
            {
                while (true)
                {
                    
                    int position = r.Next(word.Length);
                    if (!IsPositionfilled(position, WordPositions))
                    {
                        shuffledstring += word[position];
                        WordPositions.Add(position);
                        break;
                    }
                }
            }
            return shuffledstring;
        }
        static void Main(string[] args)
        {
            string word = "Hel";
            Hashtable h = new Hashtable();
            for (int count = 0; count < 1000; count++)
            {
                Thread.Sleep(1);
                string shuffledstring = shufflestring(word);
                if (h.Contains(shuffledstring))
                    h[shuffledstring] = ((int)h[shuffledstring]) + 1;
                else
                    h.Add(shuffledstring,1);
            }
            
            Console.WriteLine(word);
            foreach (DictionaryEntry e in h)
            {
                Console.WriteLine(e.Key.ToString() + " , " + e.Value.ToString()); 
            }
        }
    }
