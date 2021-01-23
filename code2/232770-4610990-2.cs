    public static class XmlWriterExtensions
    {
        private static readonly Func<XmlWriter, object> get_writer;
        private static readonly Func<object, char[]> get_bufChars;
        private static readonly Func<object, int> get_bufPos;
        private static readonly Action<object, int> set_bufPos;
        static XmlWriterExtensions()
        {
            var asm = Assembly.GetAssembly(typeof(XmlWriter));
            var xmlWellFormedWriterType = asm.GetType("System.Xml.XmlWellFormedWriter");
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var writerField = xmlWellFormedWriterType.GetField("writer", flags);
            get_writer = w => writerField.GetValue(w);
            var xmlEncodedRawTextWriterType = asm.GetType("System.Xml.XmlEncodedRawTextWriter");
            var bufCharsField = xmlEncodedRawTextWriterType.GetField("bufChars", flags);
            var bufPosField = xmlEncodedRawTextWriterType.GetField("bufPos", flags);
            get_bufChars = w => (char[])bufCharsField.GetValue(w);
            get_bufPos = w => (int)bufPosField.GetValue(w);
            set_bufPos = (w, i) => bufPosField.SetValue(w, i);
            
        }
        public static void TrimElementEnd(this XmlWriter writer)
        {
            var internalWriter = get_writer(writer);
            char[] bufChars = get_bufChars(internalWriter);
            int bufPos = get_bufPos(internalWriter);
            if (bufPos > 3 && bufChars[bufPos - 3] == ' ' && bufChars[bufPos - 2] == '/' && bufChars[bufPos - 1] == '>')
            {
                bufChars[bufPos - 3] = '/';
                bufChars[bufPos - 2] = '>';
                bufPos--;
                set_bufPos(internalWriter, bufPos);
            }
        }
    }
    // usage:
    Console.OutputEncoding = Encoding.UTF8;
    using (var writer = XmlWriter.Create(Console.Out))
    {
        writer.WriteStartElement("Foo");
        writer.WriteElementString("Bar", null);
        writer.TrimElementEnd();
        writer.WriteElementString("Baz", null);
        writer.WriteEndElement();
    }
