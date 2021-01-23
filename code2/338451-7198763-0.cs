        class MultiKeyDictionary : IDictionary
    {
        Dictionary<string, GroupInfo> stringDict = new Dictionary<string, GroupInfo>();
        Dictionary<int, GroupInfo> intDict = new Dictionary<int, GroupInfo>();
        Dictionary<GroupInfo, List<object>> keysDict = new Dictionary<GroupInfo, List<object>>();
        //Each of these would add to their own dictionary, as well as adding the backwards
        //entry in the "keysDict"
        public void Add(string memberName, GroupInfo value);
        public void Add(int key, GroupInfo value);
        public bool Contains(string key);
        public bool Contains(int key);
        //This would be the enumerator of the "keys" of "keysDict"
        //because it is actually a list of all GroupInfos
        public IDictionaryEnumerator GetEnumerator()
        public ICollection NameKeys;
        public ICollection GroupIDKeys;
        //This is to adhere to the interface. It should be carefully commented or even deprecated.
        public ICollection Keys;
        //For this, you look up the GroupInfo for the key, then do
        //foreach(object key in keysDict[<groupInfoIJustLookedUp>]) {
        //   if(key.gettype == typeof(string) stringDict.Remove(key);
        //   else if (key.gettype == typeof(int) intDict.Remove(key);
        //   else //WHAT?!?
        //}
        public void Remove(string key);
        public void Remove(int key);
        //This would be the "Keys" collection of the "keysDict"
        public ICollection Values;
        //etc... etc...
        public object this[string memberName];
        public object this[int groupId];
    }
