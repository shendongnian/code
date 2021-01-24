    class Program
    {
        static void Main(string[] args)
        {
            Action Execute = delegate { };
            ProgramTest prog = new ProgramTest(ref Execute);
            prog.AddMethod();
            prog.execute();
        }
    }
