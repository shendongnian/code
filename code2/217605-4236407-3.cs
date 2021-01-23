    class Program {
        static void Main() {
            new Program().Run();
            Console.ReadLine();
        }
        int _i = 0;
        public unsafe void Run() {
            Action incr;
            fixed (int* p_i = &_i) {
                incr = IntEx.CreateIncrementer(p_i);
            }
            incr();
            Console.WriteLine(_i); // Yay, incremented to 1!
            GC.Collect();
            incr();
            Console.WriteLine(_i); // Uh-oh, still 1!
        }
    }
