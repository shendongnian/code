    namespace JsonPath
    {
    
    
        public sealed class JsonNetValueSystem : IJsonPathValueSystem
        {
    
    
            public bool HasMember(object value, string member)
            {
                if (value is Newtonsoft.Json.Linq.JObject)
                {
                    // return (value as JObject).Properties().Any(property => property.Name == member);
    
                    foreach (Newtonsoft.Json.Linq.JProperty property in (value as Newtonsoft.Json.Linq.JObject).Properties())
                    {
                        if (property.Name == member)
                            return true;
                    }
    
                    return false;
                }
    
                if (value is Newtonsoft.Json.Linq.JArray)
                {
                    int index = ParseInt(member, -1);
                    return index >= 0 && index < (value as Newtonsoft.Json.Linq.JArray).Count;
                }
                return false;
            }
    
    
            public object GetMemberValue(object value, string member)
            {
                if (value is Newtonsoft.Json.Linq.JObject)
                {
                    var memberValue = (value as Newtonsoft.Json.Linq.JObject)[member];
                    return memberValue;
                }
                if (value is Newtonsoft.Json.Linq.JArray)
                {
                    int index = ParseInt(member, -1);
                    return (value as Newtonsoft.Json.Linq.JArray)[index];
                }
                return null;
            }
    
    
            public System.Collections.IEnumerable GetMembers(object value)
            {
                System.Collections.Generic.List<string> ls = new System.Collections.Generic.List<string>();
    
                var jobject = value as Newtonsoft.Json.Linq.JObject;
                /// return jobject.Properties().Select(property => property.Name);
    
                foreach (Newtonsoft.Json.Linq.JProperty property in jobject.Properties())
                { 
                    ls.Add(property.Name);
                }
    
                return ls;
            }
    
    
            public bool IsObject(object value)
            {
                return value is Newtonsoft.Json.Linq.JObject;
            }
    
    
            public bool IsArray(object value)
            {
                return value is Newtonsoft.Json.Linq.JArray;
            }
    
    
            public bool IsPrimitive(object value)
            {
                if (value == null)
                    throw new System.ArgumentNullException("value");
    
                return value is Newtonsoft.Json.Linq.JObject || value is Newtonsoft.Json.Linq.JArray ? false : true;
            }
    
    
            private int ParseInt(string s, int defaultValue)
            {
                int result;
                return int.TryParse(s, out result) ? result : defaultValue;
            }
    
    
        }
    
    
    }
