        static void Main(string[] args)
        {
            var t = new System.Timers.Timer(1000);
            t.Elapsed += (s, e) => CallMeBack();
            t.Start();
            Console.ReadLine();
        }
