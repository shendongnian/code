    public class SimpleObjectDictionaryMapper<TObject>
    {
        public static TObject GetObject(IDictionary<string, object> d)
        {
            PropertyInfo[] props = typeof(TObject).GetProperties();
            TObject res = Activator.CreateInstance<TObject>();
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].CanWrite && d.ContainsKey(props[i].Name))
                {
                    props[i].SetValue(res, d[props[i].Name], null);
                }
            }
            return res;
        }
    
        public static IDictionary<string, object> GetDictionary(TObject o)
        {
            IDictionary<string, object> res = new Dictionary<string, object>();
            PropertyInfo[] props = typeof(TObject).GetProperties();
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].CanRead)
                {
                    res.Add(props[i].Name, props[i].GetValue(o, null));
                }
            }
            return res;
        }
    }
