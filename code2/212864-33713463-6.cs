    public static [ObjectType] Load(string fileName)
    {
        using (var stream = System.IO.File.OpenRead(fileName))
        {
            var serializer = new XmlSerializer(typeof([ObjectType]));
            return serializer.Deserialize(stream) as [ObjectType];        
        }    
    }
