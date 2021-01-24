    using (var writer = new System.IO.StreamWriter(FileName))
        {
            var serializer = new XmlSerializer(typeof(MyItem));
            serializer.Serialize(writer, MyItem);
            writer.Flush();
        }
