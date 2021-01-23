    class CustomTextWriter : TextWriter
    {
        private string lastOutput { get; set; }
        public CustomTextWriter() { }
        public override void Write(string value)
        {
            lastOutput = value;
            Console.Write(value);
        }
        public override void WriteLine(string value)
        {
            lastOutput = value;
            Console.WriteLine(value);
        }
        public override Encoding Encoding
        {
            get
            {
                return Encoding.Default;
            }
        }
    }
    static void Main(string[] args)
    {
        ReportPrinter r = new ConsoleReportPrinter(new CustomTextWriter());
        evaluator = new Evaluator(new CompilerContext(
                            new CompilerSettings(),
                            r));
        // all evaluations now will pass through our CustomTextWriter
    }
