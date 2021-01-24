    public interface IBotCommand
    {
        string RegexMatch { get; }
        int Priority { get; }
        bool CanProcess(string input);
        void Do();
    }
    public class BotCommandOne : IBotCommand
    {
        public string RegexMatch => "[a-z]g"; // whatever regex criteria you need for bot one
        public int Priority => 1;
        public bool CanProcess(string input)
        {
            return Regex.Match(input, RegexMatch).Success;
        }
        
        public void Do()
        {
           //Do command here for bot one
        }
    }
