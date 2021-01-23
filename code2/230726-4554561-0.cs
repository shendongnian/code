    public class LookupEntry
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    
    var list = new List<LookupEntry>(new LookupEntry [] 
                                        {
                                        new LookupEntry() {Key="1", Value="Car" }, 
                                        new LookupEntry() {Key="1", Value="Truck"},
                                        new LookupEntry() {Key="2", Value="Duck"}
                                        });
    
    
    var lookup = list.ToLookup(x => x.Key, x => x.Value);
    var all1s = lookup["1"].ToList();
