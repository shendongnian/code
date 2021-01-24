        static void Main(string[] args)
        {
            Task.Run(() => { Thread.Sleep(5000); Console.WriteLine(DateTime.Now + " => I'm running after Thread.Sleep"); });
            Console.WriteLine(DateTime.Now + " => I'm running after Task.Run");
            while (true)
            {
                Thread.Sleep(500);
            }
        }
Output
`
28/05/2019 09:49:58 => I'm running after Task.Run
28/05/2019 09:50:03 => I'm running after Thread.Sleep`
