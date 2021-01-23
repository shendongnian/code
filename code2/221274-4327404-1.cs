    public class ActionHistory
    {
        private string[] _actionHistory;
        
        public IEnumerable<string> HistoryItems
        {
            get{return _actionHistory; }
        }
    }
