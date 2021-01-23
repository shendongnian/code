    public class Consumer{
        public void Test(){
            var source = new Source();
            var hashtable = ConvertToHashtable(source);
            // you haven't to write: var hashtable = ConvertToHashtable<Source>(source);
        }
    }
