    public class ParserResultCollection
    {
        private List<ParserClass> collection;
        public ParserResultCollection(string[] param)
        {
            collection = new List<ParserClass>(param);            
        }
        public void Add(ParserClass item)
        {
            collection.Add(item);
        }
        // whatever else you need.
    }
