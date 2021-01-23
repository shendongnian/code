    public class CacheOfManyObjects
    {
        private Dictionary<string, ObjectsToBeCached> ObjectsByItemPubSize{get;set;}
        //You might want to replace the IEnumerable<> with a List<>
        // but that depends on implementation
        private Dictionary<string, IEnumerable<ObjectsToBeCached>> ObjectsByItemPub{get;set;}
        public ObjectsToBeCached GetByItemPubSize(string tString);
        public IEnumerable<ObjectsToBeCached> GetByItemPub(string tString);
    }
