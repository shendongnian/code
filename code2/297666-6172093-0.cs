    public class Info
    {
        public string NewInfo { get; private set; }
        public string OldInfo { get; private set; }
        public Info(string newInfo, string oldInfo)
        {
            NewInfo = newInfo;
            OldInfo = oldInfo;
        }
    }
