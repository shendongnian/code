    class XmlnsIndentedWriter : XmlWriter
    {
        bool isRootElement;
        int indentLevel = -1;
        readonly Stream stream;
        readonly TextWriter textWriter;
        readonly XmlWriter writer;
        private XmlnsIndentedWriter(Stream output, XmlWriter baseWriter)
        {
            stream = output;
            writer = baseWriter;
        }
        private XmlnsIndentedWriter(TextWriter output, XmlWriter baseWriter)
        {
            textWriter = output;
            writer = baseWriter;
        }
        public static new XmlWriter Create(StringBuilder output, XmlWriterSettings settings)
        {
            var writer = XmlWriter.Create(output, settings);
            return new XmlnsIndentedWriter(new StringWriter(output, CultureInfo.InvariantCulture), writer);
        }
        public static new XmlWriter Create(Stream stream, XmlWriterSettings settings)
        {
            var writer = XmlWriter.Create(stream, settings);
            return new XmlnsIndentedWriter(stream, writer);
        }
        // snip: override all methods in the XmlWriter class
        private void WriteRawText(string text)
        {
            writer.Flush();
            if (stream != null)
            {
                // example only, this could be optimized with buffers, etc.
                var buf = writer.Settings.Encoding.GetBytes(text);
                stream.Write(buf, 0, buf.Length);
            }
            else if (textWriter != null)
            {
                textWriter.Write(text);
            }
        }
        public override void WriteStartDocument()
        {
            isRootElement = true;
            writer.WriteStartDocument();
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            if (isRootElement)
            {
                if (indentLevel < 0)
                {
                    // initialize the indent level;
                    // length of local name + any control characters / prefixes, etc. 
                    indentLevel = localName.Length + 1;
                }
                else
                {
                    // do not track indent for the whole document;
                    // when second element starts, we are done
                    isRootElement = false;
                    indentLevel = -1;
                }
            }
            writer.WriteStartElement(prefix, localName, ns);
        }
        public override void WriteEndAttribute()
        {
            writer.WriteEndAttribute();
            if (indentLevel >= 0)
            {
                RawText(Environment.NewLine + new string(' ', indentLevel));
            }
        }
    }
