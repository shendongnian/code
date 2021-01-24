     private Dictionary<string, string> GetDicFromQueryString(NameValueCollection queryValue)
            {
                Dictionary<string, string> dictionaryKeyValue = null;
                if (queryValue != null && queryValue.AllKeys != null)
                {
                    string value;
                    dictionaryKeyValue = new Dictionary<string, string>();
                    foreach (var k in queryValue.AllKeys)
                    {
                        if (!string.IsNullOrWhiteSpace(k))
                        {
                            value = queryValue[k];
                            dictionaryKeyValue.TryAdd(k, string.IsNullOrWhiteSpace(value) ? value : value.Replace(' ', '+'));
                        }
                    }
                }
                return dictionaryKeyValue;
            }
