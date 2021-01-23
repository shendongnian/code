    public class MyWriter : XmlWriter
    {
        private readonly XmlWriter inner;
        public MyWriter(XmlWriter inner)
        {
            this.inner = inner;
        }
        public void Dispose()
        {
            ((IDisposable) inner).Dispose();
        }
        public override void WriteStartDocument()
        {
            inner.WriteStartDocument();
        }
        public override void WriteStartDocument(bool standalone)
        {
            inner.WriteStartDocument(standalone);
        }
        public override void WriteEndDocument()
        {
            inner.WriteEndDocument();
        }
        public override void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            inner.WriteDocType(name, pubid, sysid, subset);
        }
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            inner.WriteStartElement(prefix, localName, ns);
        }
        public override void WriteEndElement()
        {
            inner.WriteFullEndElement();
        }
        public override void WriteFullEndElement()
        {
            inner.WriteFullEndElement();
        }
        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            inner.WriteStartAttribute(prefix, localName, ns);
        }
        public override void WriteEndAttribute()
        {
            inner.WriteEndAttribute();
        }
        public override void WriteCData(string text)
        {
            inner.WriteCData(text);
        }
        public override void WriteComment(string text)
        {
            inner.WriteComment(text);
        }
        public override void WriteProcessingInstruction(string name, string text)
        {
            inner.WriteProcessingInstruction(name, text);
        }
        public override void WriteEntityRef(string name)
        {
            inner.WriteEntityRef(name);
        }
        public override void WriteCharEntity(char ch)
        {
            inner.WriteCharEntity(ch);
        }
        public override void WriteWhitespace(string ws)
        {
            inner.WriteWhitespace(ws);
        }
        public override void WriteString(string text)
        {
            inner.WriteString(text);
        }
        public override void WriteSurrogateCharEntity(char lowChar, char highChar)
        {
            inner.WriteSurrogateCharEntity(lowChar, highChar);
        }
        public override void WriteChars(char[] buffer, int index, int count)
        {
            inner.WriteChars(buffer, index, count);
        }
        public override void WriteRaw(char[] buffer, int index, int count)
        {
            inner.WriteRaw(buffer, index, count);
        }
        public override void WriteRaw(string data)
        {
            inner.WriteRaw(data);
        }
        public override void WriteBase64(byte[] buffer, int index, int count)
        {
            inner.WriteBase64(buffer, index, count);
        }
        public override void Close()
        {
            inner.Close();
        }
        public override void Flush()
        {
            inner.Flush();
        }
        public override string LookupPrefix(string ns)
        {
            return inner.LookupPrefix(ns);
        }
        public override WriteState WriteState
        {
            get { return inner.WriteState; }
        }
    }
