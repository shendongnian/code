    public class Effect
    {
        private static int _lastId;
        public Effect()
        {
            InternalId = _lastId++;
        }
        public string Name 
        {
            get { return "Effect" + InternalId.ToString(); }
        }
        public int InternalId ...
    }
