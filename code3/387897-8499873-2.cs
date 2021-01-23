    class Program
    {
        static void Main(string[] args)
        {
            var SubLogic = "darere|gfgfgg|gfgfg";
            using (var sr = new StringReader(SubLogic))
            {
                var str = string.Empty;
                int charValue;
                do
                {
                    charValue = sr.Read();
                    var c = (char)charValue;
                    if (c == '|' || (charValue == -1 && str.Length > 0))
                    {
                        Process(str);
                        str = string.Empty; // Reset the string
                    }
                    else
                    {
                        str += c;
                    }
                } while (charValue >= 0);
            }
            Console.ReadLine();
        }
        private static void Process(string str)
        {
            // Your actual Job
            Console.WriteLine(str);
        }
