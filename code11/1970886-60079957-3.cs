    public static class ApiCodes
    {
        public static ActionCodes ActionCodes { get; } = ActionCodes.Instance;
    }
    public class ActionCodes
    {
        public static ActionCodes Instance { get; } = new ActionCodes();
        // Singleton: private constructor
        private ActionCodes()
        {
        }
        public string Add { get; } = "ADD";
        public string Delete { get; } = "REM";
    }
