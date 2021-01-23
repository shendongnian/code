    public class TestSerialize
    {
        [DataContract(Name = "Parameter")]
        public struct Parameter
        {
            [DataMember(Name = "ValueName")] string ValueName;
            [DataMember(Name = "Value")] int Value;
            public Parameter(string ValueName, int Value)
            {
                this.ValueName = ValueName;
                this.Value = Value;
            }
        }
        [CollectionDataContract(Name = "MyClass", ItemName = "Parameter")]
        public class ParameterList : List<Parameter>
        {
        }
        public string Serialize(ParameterList plist)
        {
            var serializer = new DataContractSerializer(plist.GetType());
            var output = new StringBuilder();
            var xmlWriter = XmlWriter.Create(output);
            serializer.WriteObject(xmlWriter, plist);
            xmlWriter.Close();
            return output.ToString();
        }
        public void Serialize_produces_2Levels_of_xml()
        {
            ParameterList p = new ParameterList
            {
                new Parameter("First", 1),
                new Parameter("Second", 2),
            };
            var xml = Serialize(p);
        }
    }
