        static void Main(string[] args)
        {
            string msg = null;
            List<string> layoutListNames = new List<string>() { "test1","test2"};
            foreach (string name in layoutListNames)
            {
                if (msg != null) msg += "\n";
                msg += name;
            }
            Console.WriteLine("at 1:" + msg);
            msg = string.Join("\n", layoutListNames.ToArray());
            Console.WriteLine("at 2:" + msg);
            Console.Read();
        }
