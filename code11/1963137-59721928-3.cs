    public class MasterClassDictionary
    {
        public Dictionary<int, SubClass1> subClass1Dict{get;} = new Dictionary<int, SubClass1>()
        public Dictionary<int, SubClass2> subClass2Dict{get;} = new Dictionary<int, SubClass2>()
        public void Add(MasterClass item)
        {
            int val = item.Stuff();
            if (item is SubClass1)
            {
                subClass1Dict[val] = item;
            }
            if (item is SubClass2)
            {
                subClass2Dict[val] = item;
            }
        }
    }
