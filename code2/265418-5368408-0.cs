        private static Queue<String> q = new Queue<String>(1000);
        private static void WriteToConsole(String message)
        {
            q.Enqueue(message);
            Console.Write(message);
        }
        private static void WriteToConsole(String message, params Object[] r)
        {
            String s = String.Format(message, r);
            q.Enqueue(s);
            Console.Write(s);
        }
