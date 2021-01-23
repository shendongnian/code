    static public class ObjectMapping
    {
        static Dictionary<int, object> dictionary = new Dictionary<int, object>();
        static public object GetObjectForNumber(int x)
        {
            object o;
            if (!dictionary.ContainsKey(x))
            {
                o = CreateObjectForNumberTheFirstTime(x);
                dictionary.Add(x, o);
                return o;
            }
            return dictionary[x];
        }
    }
