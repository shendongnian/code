        private static string randomCase(string word)
        {
            string changed;
            Random r = new Random(Guid.NewGuid().GetHashCode());
            int n = r.Next(1, 29);
            // Output number to check it's not the same each time
            //MessageBox.Show(n.ToString());
            //Console.WriteLine(n.ToString());
            if (n >= 1 && n <= 9)
            {
                // First letter capatalised
                changed = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToLower());
                return changed;
            }
            else if (n >= 10 && n <= 19)
            {
                // Word capitalised 
                changed = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word.ToUpper());
                return changed;
            }
            else if (n >= 20 && n <= 29)
            {
                // Word left as lower case
                return word;
            }
            return null;
        }
        public static void Main(string[] args)
        {
            //Your code goes here
            for (int i = 0; i < 10; i++)
                Console.WriteLine(randomCase("heLLo"));
        }
