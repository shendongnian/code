    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
     namespace SampleTaskStop
    {
    class Program
    {
        static public void SetValue(string address, int value)
        {
            while (!_cancelled)
            {
                //vam.WriteInt32((IntPtr)address1, 6969); //value to loop.
            }
            Console.WriteLine(address + " - completed");
        }
        static bool _cancelled = false;
        static void Main(string[] args)
        {
            while (true) //outer loop
            {
                Console.Title = "SlavScripts";
                Console.WriteLine("---SlavScripts v2.0---");
                Console.WriteLine("");
                Console.WriteLine("[1] Player Options");
                Console.WriteLine("");
                string answer = "";
                answer = Console.ReadLine();
                _cancelled = false;
                if (answer == "1")
                {
                    var acceptUserInput = Task.Factory.StartNew(AcceptUserInput);
                    acceptUserInput.Wait();
                }
            }
        }
        private static void AcceptUserInput()
        {
            // Task to perform the value setting in the
            Task computationTask = null;
            Console.WriteLine("Enter Player Input");
            Console.WriteLine("1 God Mode");
            Console.WriteLine("2 Armour Mode");
            Console.WriteLine("Press Esc to cancel");
            var key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Escape)
            {
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1 )
                {
                    Console.WriteLine("Godmode Enabled");
                    Console.WriteLine("");
                    _cancelled = true;
                    if (computationTask != null)
                    {
                        computationTask.Wait(new System.Threading.CancellationToken());
                    }
                    _cancelled = false;
                    computationTask = Task.Factory.StartNew(() => SetValue("data1", 6979));
                }
                else if (key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("Infinite Armor Enabled");
                    Console.WriteLine("");
                    _cancelled = true;
                    if (computationTask != null)
                    {
                        computationTask.Wait(new System.Threading.CancellationToken());
                    }
                    _cancelled = false;
                    
                    computationTask = Task.Factory.StartNew(() => SetValue("data2", 6979));
                }
                key = Console.ReadKey(true);
            }
            _cancelled = true;
            Console.Write("Computation was cancelled");
        }
    }
}
