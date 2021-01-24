    static void Main(string[] args)
        {
            var list = new List<string> {"a", "b", "c", "d", "a", "b", "a"};
            var myDict = new Dictionary<string, int>();
            foreach (var letter in list)
            {
                if (!myDict.ContainsKey(letter))
                {
                    myDict.Add(letter, 1);
                }
                else
                {
                    myDict[letter]++;
                }
            }
            foreach (var letter in myDict.Keys)
            {
                Console.WriteLine($"{letter} : {myDict[letter]}");
            }
            Console.ReadKey();
        }
