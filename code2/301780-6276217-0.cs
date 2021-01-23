    class Args {
        static void Main(string[] args) {
            for (int i = 0; i < args.Length; i++) {
                System.Console.WriteLine("[{0}]=<{1}>", i, args[i]);
            }
        }
    }
