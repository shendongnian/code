        // called every 3 seconds.
        private static void TimerCallback(Object o)
        {            
            Console.WriteLine("Draw something.... ");
        }
        static void Main(string[] args)
        {
            Console.Write("How many levels high do you want the tree to be :");
            int input = Convert.ToInt32(Console.ReadLine());
            int treeHeight = input, Space, sX;
            Console.WriteLine("Tree:");
            // Timer.
            var t = new Timer(TimerCallback, null, 0, 3000);
            // Prevent the app from closing
            Console.ReadLine();
        }
