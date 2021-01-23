    public class Gen2
    {
        private static List<string> allFiNames = new List<string> allFiNames();
        public static List<string> AllFiNames { get { return allFiNames; } }
    
        private static Dictionary<string, string> longNames = new Dictionary<string, string>();
        public static Dictionary<string, string> LongNames { get { return longNames; } }
    
        private static Dictionary<string, string> apiKeys = new Dictionary<string, string>();
        public static Dictionary<string, string> ApiKeys { get { return apiKeys; } }
    
        private static Dictionary<string, string> connectStrings = Dictionary<string, string>();
        public static Dictionary<string, string> ConnectStrings { get { return connectStrings; } }
    }
