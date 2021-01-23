    using System;
    using System.Runtime.CompilerServices;
    
    class Program
    {
        public int AutomaticallyImplemented { get; set; }
        public int HandWritten {
            get { return 0; }
            set {}
        }
        
        static void Main()
        {
            foreach (var property in typeof(Program).GetProperties())
            {
                bool auto = property.GetGetMethod().IsDefined
                    (typeof(CompilerGeneratedAttribute), false);
                Console.WriteLine("{0}: {1}", property.Name, auto);
            }
        }
    }
