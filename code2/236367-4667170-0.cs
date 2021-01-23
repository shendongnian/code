    public class MyDictionary : List<KeyValuePair<string, string>>
    {
        ...
        public void Put(params string[][] p)
        {
            foreach (var a in p)
                Add(new KeyValuePair<string, string>(a[0], a[1]));
        }
    }
