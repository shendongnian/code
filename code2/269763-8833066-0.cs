    using (var ms = new MemoryStream())
    {
         using (var writer = XmlWriter.Create(ms))
        {
            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(writer, objectToSave);
            writer.Flush();
            ms.Position = 0;        
        }
        using (StreamReader rdr = new StreamReader(ms))
        {
            return rdr.ReadToEnd();
        }
    }
