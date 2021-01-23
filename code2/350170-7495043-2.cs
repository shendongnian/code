    class SomeType
    {
        public int SomeData = 5;
    
        public override string ToString()
        {
            return SomeData.ToString();
        }
    }
    // ...
    Hashtable blah = new Hashtable();
    blah.Add("test", new SomeType() { SomeData = 6 });
    foreach (DictionaryEntry item in blah)
    {
        if(((SomeType)e.Value).SomeData == 6)
        {
            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
        }
    }
