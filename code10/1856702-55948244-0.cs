    public class Parameters
    {
        public static string GetCommandLineArg(params string[] args)
            => Environment.GetCommandLineArgs().SkipWhile(x => !args.Contains(x, StringComparer.InvariantCultureIgnoreCase)).Skip(1).FirstOrDefault();
        public static string ResultsDirectory => GetCommandLineArg("-r", "--result-directory");
        public static string Logger => GetCommandLineArg("-l", "--logger");
    }
