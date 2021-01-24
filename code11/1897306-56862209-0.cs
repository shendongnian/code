    private static IDictionary<string, string> FlattenJObjectToDictionary(JObject obj)
    {
        // obtain a key/value enumerable and convert it to a dictionary
        return NestedJObjectToFlatEnumerable(obj, null).ToDictionary(kv => kv.Key, kv => kv.Value);
    }
    private static IEnumerable<KeyValuePair<string, string>> NestedJObjectToFlatEnumerable(JObject data, string path = null)
    {
        // path will be null or a value like Three:Three: (where Three:Three is the parent chain)
        // go through each property in the json object
        foreach (var kv in data.Properties())
        {
            // if the value is another jobject, we'll recursively call this method
            if (kv.Value is JObject)
            {
                var childDict = (JObject)kv.Value;
                // build the child path based on the root path and the property name
                string childPath = path != null ? string.Format("{0}{1}:", path, kv.Name) : string.Format("{0}:", kv.Name);
                // get each result from our recursive call and return it to the caller
                foreach (var resultVal in NestedJObjectToFlatEnumerable(childDict, childPath))
                {
                    yield return resultVal;
                }
            }
            else if (kv.Value is JArray)
            {
                throw new NotImplementedException("Encountered unexpected JArray");
            }
            else
            {
                // this kind of assumes that all values will be convertible to string, so you might need to add handling for other value types
                yield return new KeyValuePair<string, string>(string.Format("{0}{1}", path, kv.Name), Convert.ToString(kv.Value));
            }
        }
    }
