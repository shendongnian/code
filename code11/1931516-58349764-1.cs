    class Program
    {
        static void Main(string[] args)
        {
            // args a space separated array so you should use an array for your test
            // args are identified with the `-` so you should set args like `-f somefilenamehere`
            // args specified are -f and -v
            string[] arguments = new[] {"-f file:xxxx\\xxxx\\xxxxx.sh", "-v nsdd" };
            string file = string.Empty;
            string value = string.Empty;
            // you would pull your args off the options, if they are successfully parsed
            // and map them to your applications properties/settings
            Parser.Default.ParseArguments<Options>(arguments)
                .WithParsed<Options>(o =>
                {
                    file = o.InputFile; // map InputFile arg to file property
                    value = o.Value; // map Value arg to value property
                });
            
            Console.WriteLine($"file = {file}");
            Console.WriteLine($"value = {value}");
            Console.ReadLine();
            // output:
            // file =  file:xxxx\xxxx\xxxxx.sh
            // value =  nsdd
        }        
    }
    // the options class is used to define your arg tokens and map them to the Options property
    class Options
    {
        [Option('f', "file", Required = true, HelpText = "Input files to be processed.")]
        public string InputFile { get; set; }
        
        [Option('v', "value", Required = true, HelpText = "Value to be used")]
        public string Value { get; set; }
    }
