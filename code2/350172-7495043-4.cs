    class SomeType
    {
        public int SomeData = 5;
    
        public override string ToString()
        {
            return SomeData.ToString();
        }
    }
    // ...
    var blah = new Dictionary<string, SomeType>();
    blah.Add("test", new SomeType() { SomeData = 6 });
    foreach (KeyValuePair<string, SomeType> item in blah)
    {
        if(e.Value.SomeData == 6)
        {
            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
        }
    }
