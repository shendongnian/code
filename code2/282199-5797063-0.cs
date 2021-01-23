    class Program
    {
        private static Dictionary<string, List<string>> _arrayLists = new Dictionary<string, List<string>>();
        static void Main(string[] args)
        {
            string filePath = "c:\\logs\\arrays.txt";
            StreamReader reader = new StreamReader(filePath);
            string line;
            string category = "";
            while (null != (line = reader.ReadLine()))
            {
                if (line.ToLower().Contains("start"))
                {
                    string[] splitHeader = line.Split("-".ToCharArray());
                    category = splitHeader[1].Trim();
                }
                else
                {
                    if (!_arrayLists.ContainsKey(category))
                    {
                        List<string> stringList = new List<string>();
                        _arrayLists.Add(category, stringList);
                    }
                    if((!line.ToLower().Contains("end")&&(line.Trim().Length > 0)))
                    {
                        _arrayLists[category].Add(line.Trim());
                    }
                }
            }
            //testing
            foreach(var keyValue in _arrayLists)
            {
                Console.WriteLine("Category: {0}",keyValue.Key);
                foreach(var value in keyValue.Value)
                {
                    Console.WriteLine("{0}".PadLeft(5, ' '), value);
                }
            }
            Console.Read();
        }
    }
