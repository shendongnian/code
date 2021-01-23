    private static void ImportDerivedClasses()
    {
        List<Base> bases;
        string filePathAndName = @"c:\temp\SerializedBases.xml";
        using (FileStream fileStream = new FileStream(filePathAndName, FileMode.Open))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Base>));
            bases = xmlSerializer.Deserialize(fileStream) as List<Base>;
        }
        List<Base> deserializedBases = new List<Base>();
        foreach(Base baseClass in bases)
        {
            switch (baseClass.Attr)
            {
                case "1":
                    deserializedBases.Add(new Derived1());
                    break;
                case "2":
                    deserializedBases.Add(new Derived2());
                    break;
                default:
                    // Log warning
                    break;
            }
        }
    }
