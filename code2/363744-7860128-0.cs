        class KeyWrapper
        {
            public List<Key> Keys { get; set; }
        }
        class Key
        {
            public string RegistrationKey { get; set; }
            public string ValidationStatus { get; set; }
            public string ValidationDescription { get; set; }
            public List<Properties> Properties { get; set; }
        }
        public class Properties
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
        public void DeserializeKeys()
        {            
            const string json = @"{""Keys"": 
                [
                    {
                        ""RegistrationKey"": ""asdfasdfa"",
                        ""ValidationStatus"": ""Valid"",
                        ""ValidationDescription"": null,
                        ""Properties"": [
                            {
                                ""Key"": ""Guid"",
                                ""Value"": ""i0asd23165323sdfs68661358""
                            }
                        ]
                     }
                 ]
             }";
            var keysWrapper = Newtonsoft.Json.JsonConvert.DeserializeObject<KeyWrapper>(json);
     }
