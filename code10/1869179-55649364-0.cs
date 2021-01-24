lang=csharp
    [Serializable]
    public class Class1
    {
        [XmlElement(Type = typeof(string[][]))]
        public string[][] MyJaggedArray { get; set; }
    }
