        static int myVar = 100;
        public static void Main()
        {
            Task.Run(() => Health());
            ListenForKill();
        }
        public static void Health()
        {
            while (true)
            {
                if (myVar == 0)
                {
                    Console.WriteLine("Dead");
                }
            }
        }
        public static void ListenForKill()
        {
            if (Console.ReadLine().Equals("kill"))
            {
                myVar = 0;
            }
            //this way program won't exit
            ListenForKill();
        }
