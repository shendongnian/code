    [DataContract]
    class FooBar
    {
        //this property doesn't have the DataMember attribure 
        //and thus won't be serialized
        public string OriginalXml { get; set; }
        [DataMember] private int _foo;
        [DataMember] private string _bar;
        static public FooBar Deserialize(XmlReader reader)
        {
            var fooBar = 
               (FooBar)new DataContractSerializer(typeof(FooBar)).ReadObject(reader);
            fooBar.OriginalXml = reader.ToString();
            return fooBar;
        }        
    }
