    class MyConsole
    {
        public static string ReadLine()
        {
            return System.Console.ReadLine();
        }
        public static string ReadLine(string message)
        {
            System.Console.WriteLine(message);
            return ReadLine();
        }
        // add whatever other methods you need
    }
