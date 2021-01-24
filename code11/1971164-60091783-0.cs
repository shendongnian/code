        static bool ContainsBlacklistedWords(string password, string[] blacklist)
        {
            return blacklist.Any(s => password.Contains(s, StringComparison.CurrentCultureIgnoreCase));
        }
        static void Main(string[] args)
        {
            string password = "foobar";
            string[] blacklist = new[] { "hello", "password" };
            
            if (ContainsBlacklistedWords(password, blacklist))
            {
                Console.WriteLine("Contains blocked words.");
            }
            else
            {
                Console.WriteLine("OK");
            }
         }
