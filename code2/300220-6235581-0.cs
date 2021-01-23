        static Dictionary<string, Action<List<string>>> commandMapper;
        static void Main(string[] args)
        {
            InitMapper();
            Invoke("TOPIC", new string[]{"1","2","3"}.ToList());
            Invoke("Topic", new string[] { "1", "2", "3" }.ToList());
            Invoke("Browse", new string[] { "1", "2", "3" }.ToList());
            Invoke("BadCommand", new string[] { "1", "2", "3" }.ToList());
        }
        private static void Invoke(string command, List<string> args)
        {
            command = command.ToLower();
            if (commandMapper.ContainsKey(command))
            {
                // Execute the method
                commandMapper[command](args);
            }
            else
            {
                // Command not found
                Console.WriteLine("{0} : Command not found!", command);
            }
        }
        private static void InitMapper()
        {
            // Add more command to the mapper here as you have more
            commandMapper = new Dictionary<string, Action<List<string>>>();
            commandMapper.Add("topic", Topic);
            commandMapper.Add("browse", Browse);
        }
        static void Topic(List<string> args)
        {
            // ..
            Console.WriteLine("Executing Topic");
        }
        static void Browse(List<string> args)
        {
            // ..
            Console.WriteLine("Executing Browse");
        }
