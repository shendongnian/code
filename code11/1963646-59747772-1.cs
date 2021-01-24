    public class HomeStrategy : StrategyBase
    {
        public string FileType => ".txt";
    
        public override bool CanProcess(string text)
        {
            return text.Contains("house") || text.Contains("flat");
        }
    }
