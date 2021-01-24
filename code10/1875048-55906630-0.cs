            public class FilterDto
            {
                private const string DefaultValue = "Default code";
    
                [OnDeserialized]
                internal void OnDeserializedMethod(StreamingContext context)
                {
                    if (Code == DefaultValue)
                    {
                        Code = null; //set to null or string.empty
                    }
                }
    
                public string Code { get; set; } = DefaultValue;
                public string Description { get; set; }
            }
