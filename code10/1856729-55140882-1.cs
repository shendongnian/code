    class Program
    {
        static void Main(string[] args)
        {
            Action Execute = delegate { };            
            ProgramTest prog = new ProgramTest(ref Execute);
            Execute += prog.Print;
            prog.AddMethod();
            Execute();
            
        }
    }
