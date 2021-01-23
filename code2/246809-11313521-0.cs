    class DumpWriter : TextWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
    }
    ...
    static int Main(String[] args)
    {
    ...
    #if !DEBUG
        DumpWriter dump = new DumpWriter();
        Console.SetOut(dump);
        Console.SetError(dump);
    #endif
    ...
    }
