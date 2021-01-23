    public void test()
    { 
        string outfile = @"C:\Folder\Tester.xml";
        
        Serialize<List<Opgave>>(arrAktiveOpgaver, outfile)//serialize data
        arrAktiveOpgaver = DeserializeFromXml<List<Opgave>>(outfile);//deserialize data
    }
    public static T DeserializeFromXml<T>(string inputFile)
    {
        XmlSerializer s = new XmlSerializer(typeof(T));
        T deserializedObject = default(T);
        using (TextReader textReader = new StreamReader(inputFile))
        {
            deserializedObject = (T)s.Deserialize(textReader);
            textReader.Close();
        }
        return deserializedObject;
    }
    public static void SerializeToXml<T>(T objToSerialize, string outputFile)
    {
        XmlSerializer s = new XmlSerializer(objToSerialize.GetType());
        using (TextWriter textWriter = new StreamWriter(outputFile))
        {
            s.Serialize(textWriter, objToSerialize);
            textWriter.Close();
        }
    }
