        public static void Main(string[] args)
        {
            if ((((args == null) || (args.Length != 1)) || (args[0] == "-?")) || (args[0] == "-h"))
            {
                Usage();
            }
            else
            {
                try
                {
                    Console.WriteLine(Assembly.LoadFrom(args[0]).FullName.ToString());
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Exception: {0}", exception.ToString());
                    Usage();
                }
            }
        }
