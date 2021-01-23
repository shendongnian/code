    Dictionary<string,object> coll = new Dictionary<string,object>();
        coll.Add("Prop1","hello");
        coll.Add("Prop2",1);
        System.Dynamic.ExpandoObject obj = dic.Expando();
    //You can have this ext method to better help
    
    public static ExpandoObject Expando(this IEnumerable<KeyValuePair<string, object>> 
    dictionary)
            {
                var expando = new ExpandoObject();
                var expandoDic = (IDictionary<string, object>)expando;
                foreach (var item in dictionary)
                {
                    expandoDic.Add(item);
                }
                return expando;
            }
