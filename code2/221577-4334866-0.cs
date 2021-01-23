            public class MetadataEncoderElement : ConfigurationElement
        {
            [ConfigurationProperty("fileName", IsRequired = true)]
            public String FileName
            {
                get
                {
                    return string.Format((String)this["fileName"], DateTime.Now);
                }
            }
        }
