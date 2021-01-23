       private static Stream SerializeBinaryWithDictionary(Person person,DataContractSerializer serializer)
        {
            var stream = new MemoryStream();
            var dictionary = new XmlDictionary();
            var session = new XmlBinaryWriterSession();
            var key = 0;
            session.TryAdd(dictionary.Add("FirstName"), out key);
            session.TryAdd(dictionary.Add("LastName"), out key);
            session.TryAdd(dictionary.Add("Birthday"), out key);
            session.TryAdd(dictionary.Add("Person"), out key);
            session.TryAdd(dictionary.Add("http://www.friseton.com/Name/2010/06"),out key);
            session.TryAdd(dictionary.Add("http://www.w3.org/2001/XMLSchema-instance"),out key);
            var writer = XmlDictionaryWriter.CreateBinaryWriter(stream, dictionary, session);
            serializer.WriteObject(writer, person);
            writer.Flush();
            return stream;
        }
