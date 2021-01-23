    class Program
    {
       [Flags]   // <--
       private enum Subject 
       { 
           History = 1, Math = 2, Geography = 4    // <-- Powers of 2
       }
        static void Main(string[] args)
        {
            Console.WriteLine(addSubject(Subject.History));
        }
        private static Subject addSubject(Subject H)
        {
            return H & Subject.Math;
        }
    }
