    public static class XmlExtensions
    {
        public static MemoryStream ToStream(this XmlReader reader)
        {
            MemoryStream ms = new MemoryStream();
            reader.CopyTo(ms);
            return ms;
        }
        public static FileStream ToStream(this XmlReader reader, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            reader.CopyTo(fs);
            return fs;
        }
        public static void CopyTo(this XmlReader reader, Stream s)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.CheckCharacters = false; // don't get hung up on technically invalid XML characters
            settings.CloseOutput = false; // leave the stream open
            using (XmlWriter writer = XmlWriter.Create(s, settings))
            {
                writer.WriteNode(reader, true);
            }
        }
    }
