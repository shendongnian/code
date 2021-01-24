    class CommandLine
    {
         static void Main(string[] args)
        {
            // The Length property provides the number of array elements.
            Console.WriteLine($"parameter count = {args.Length}");
            // Get values using the `args` array in your case you will have:
            // args[0] = "-m";
            // args[1] = "message";
            // args[2] = "-p";
            // args[3] = "phonenumber";
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"Arg[{i}] = [{args[i]}]");
            }
        }
    }
