    public class StackOverflow_7003740
    {
        static Dictionary<string, object> NvcToDictionary(NameValueCollection nvc, bool handleMultipleValuesPerKey)
        {
            var result = new Dictionary<string, object>();
            foreach (string key in nvc.Keys)
            {
                if (handleMultipleValuesPerKey)
                {
                    string[] values = nvc.GetValues(key);
                    if (values.Length == 1)
                    {
                        result.Add(key, values[0]);
                    }
                    else
                    {
                        result.Add(key, values);
                    }
                }
                else
                {
                    result.Add(key, nvc[key]);
                }
            }
            return result;
        }
        public static void Test()
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("foo", "bar");
            nvc.Add("multiple", "first");
            nvc.Add("multiple", "second");
            foreach (var handleMultipleValuesPerKey in new bool[] { false, true })
            {
                if (handleMultipleValuesPerKey)
                {
                    Console.WriteLine("Using special handling for multiple values per key");
                }
                var dict = NvcToDictionary(nvc, handleMultipleValuesPerKey);
                string json = new JavaScriptSerializer().Serialize(dict);
                Console.WriteLine(json);
                Console.WriteLine();
            }
        }
    }
