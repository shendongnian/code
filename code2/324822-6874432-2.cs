    StringDictionary strDict = new StringDictionary();
        // + Strong Type
        // - lowercases the key
        // - random order ?
        // - older approach, .Net 1 which predates generics
                
    Dictionary&lt;string, string&gt; dict = new Dictionary&lt;string, string&gt;();
        // + Strong Type
        // - random order ?
                
    List&lt;KeyValuePair&lt;string, string&gt;&gt; listKVP = new List&lt;KeyValuePair&lt;string, string&gt;&gt;();
        // + Strong Type
        // + Keeps order as inserted
        // - more complex to instanciate and use
                
    Hashtable hash = new Hashtable();
        // Automatically sorted by hash code
        // Better for big collections
        // - not strong typed
                
    ListDictionary listDict = new ListDictionary();
        // + faster than Hashtable for small collections (smaller than 10)
        // - not strong typed
                
    HybridDictionary hybridDict = new HybridDictionary();
        // Better compromise if unsure of length of collection
        // - not strong typed
                
    OrderedDictionary orderDict = new OrderedDictionary();
        // + Keeps order as inserted
        // - not strong typed
            
    SortedDictionary&lt;string, string&gt; sortedDict = new SortedDictionary&lt;string, string&gt;();
        // + Strong Type
        // Automatically sorted by key
        // + faster lookup than the Dictionary [<a href="http://msdn.microsoft.com/en-us/library/6tc79sx1(v=vs.80).aspx">msdn</a>]
            
    SortedList&lt;string, string&gt; sortedList = new SortedList&lt;string, string&gt;();
        // + Strong Type
        // Automatically sorted by key
        // Almost same as SortedDict, but can access by index []
                
    KeyValuePair&lt;string, string&gt;[] arrayKVP = new KeyValuePair&lt;string, string&gt;[123];
        // + Strong Type
        // + Keeps order as inserted
        // - Fixed size
