    public class Pair
    {
        public object Value1
        {
            get;
            set;
        }
        public object Value2
        {
            get;
            set;
        }
    }
    
    //somewhere in another class
    public Dictionary<string, Pair> Compare<T>(T object1, T object2)
    {
        var props = typeof(T).GetProperties().Where(pi => pi.CanRead); //this will return only public readable properties. Modify if you need something different
        Dictionary<string, Pair> result = new Dictionary<string, Pair>();
        foreach (var prop in props)
        {
            var val1 = prop.GetValue(object1, null); //indexing properties are ignored here
            var val2 = prop.GetValue(object2, null);
            if (val1 != val2) //maybe some more sophisticated compare algorithm here, using IComparable, nested objects analysis etc.
            {
                result[prop.Name] = new Pair { Value1 = val1, Value2 = val2 };
            }
        }
        return result;
    }
