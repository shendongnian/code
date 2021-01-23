    using System.Runtime.InteropServices;
    using System.Threading;
    namespace LagTimer
    {
        class Program
        {
            [return: MarshalAs(UnmanagedType.Bool)]
            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern bool BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool fBlockIt);
            static void Main(string[] args)
            {
                Thread t = new Thread(LagTick);
                t.Start();
                while (true) { } // Prevent the app from exiting
            }
            static void LagTick()
            {
                while (true)
                {
                    BlockInput(true);
                    System.Threading.Thread.Sleep(250);
                    BlockInput(false);
                    // TODO: Randomize time in between ticks
                    Thread.Sleep(100);
                    // TODO: Add logic for when to "sputter" the mouse
                }
            }
        }
    }
