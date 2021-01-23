    public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var name = binder.Name; 
                //Code to check if key is of form __numeric__<number> so that numeric keys can be accessed
                if (binder != null && binder.Name != null && binder.Name.StartsWith("__numeric__"))
                {
                    name = binder.Name.Substring(11);
                }
    
                if (!_dictionary.TryGetValue(name, out result))
                {
                    // return null to avoid exception.  caller can check for null this way...
                    result = null;
                    return true;
                }
    
                var dictionary = result as IDictionary<string, object>;
                if (dictionary != null)
                {
                    result = new DynamicJsonObject(dictionary);
                    return true;
                }
    
                var arrayList = result as ArrayList;
                if (arrayList != null && arrayList.Count > 0)
                {
                    if (arrayList[0] is IDictionary<string, object>)
                        result = new List<object>(arrayList.Cast<IDictionary<string, object>>().Select(x => new DynamicJsonObject(x)));
                    else
                        result = new List<object>(arrayList.Cast<object>());
                }
    
                return true;
            }
