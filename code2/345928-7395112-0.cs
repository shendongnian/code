    public Class1()
            {
                string json = @"{
                                    ""name"": ""test"",
                                    ""father"": {
                                         ""name"": ""test2"",
                                         ""age"": 13,
                                         ""dog"": {
                                             ""color"": ""brown""
                                         }
                                    }
                                }";
    
                var reader = new JsonFx.Json.JsonReader();
                dynamic output = reader.Read(json);
                Dictionary<string, object> dict = new Dictionary<string, object>();
                
                GenerateDictionary((System.Dynamic.ExpandoObject) output, dict, "");
            }
    
            private void GenerateDictionary(System.Dynamic.ExpandoObject output, Dictionary<string, object> dict, string parent)
            {
                foreach (var v in output)
                {
                    string key = parent + v.Key;
                    object o = v.Value;
    
                    if (o.GetType() == typeof(System.Dynamic.ExpandoObject))
                    {
                        GenerateDictionary((System.Dynamic.ExpandoObject)o, dict, key + ".");
                    }
                    else
                    {
                        if (!dict.ContainsKey(key))
                        {
                            dict.Add(key, o);
                        }
                    }
                }
            }
