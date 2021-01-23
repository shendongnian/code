    public class ModelConverter   : JavaScriptConverter
        {
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");
                
                if (type == typeof(Model))
                {
                    Model result = new Model();
                    foreach (var item in dictionary.Keys)
                    {
                        if (dictionary[item] is string && item == "Values")
                            result.Values = new string[] { (string)dictionary[item] };
                        else if(item=="Values")
                            result.Values = (string[])((ArrayList)dictionary[item]).ToArray(typeof(string));
                            
                    }
                    return result;
                }
                return null;
            }
    
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }
    
            public override IEnumerable<Type> SupportedTypes
            {
                get { return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(Model) })); }
            }
        }
