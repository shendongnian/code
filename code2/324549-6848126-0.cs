    public class StackOverflow_6846012
    {
        class MyWriter : XmlWriter
        {
            XmlWriter inner;
            public MyWriter(XmlWriter inner)
            {
                this.inner = inner;
            }
            public override void Close()
            {
                this.inner.Close();
            }
            public override void Flush()
            {
                this.inner.Flush();
            }
            public override string LookupPrefix(string ns)
            {
                return this.inner.LookupPrefix(ns);
            }
            public override void WriteBase64(byte[] buffer, int index, int count)
            {
                this.inner.WriteBase64(buffer, index, count);
            }
            public override void WriteCData(string text)
            {
                this.inner.WriteCData(text);
            }
            public override void WriteCharEntity(char ch)
            {
                this.inner.WriteCharEntity(ch);
            }
            public override void WriteChars(char[] buffer, int index, int count)
            {
                this.inner.WriteChars(buffer, index, count);
            }
            public override void WriteComment(string text)
            {
                this.inner.WriteComment(text);
            }
            public override void WriteDocType(string name, string pubid, string sysid, string subset)
            {
                this.inner.WriteDocType(name, pubid, sysid, subset);
            }
            public override void WriteEndAttribute()
            {
                this.inner.WriteEndAttribute();
            }
            public override void WriteEndDocument()
            {
                this.inner.WriteEndDocument();
            }
            public override void WriteEndElement()
            {
                this.inner.WriteFullEndElement();
            }
            public override void WriteEntityRef(string name)
            {
                this.inner.WriteEntityRef(name);
            }
            public override void WriteFullEndElement()
            {
                this.inner.WriteFullEndElement();
            }
            public override void WriteProcessingInstruction(string name, string text)
            {
                this.inner.WriteProcessingInstruction(name, text);
            }
            public override void WriteRaw(string data)
            {
                this.inner.WriteRaw(data);
            }
            public override void WriteRaw(char[] buffer, int index, int count)
            {
                this.inner.WriteRaw(buffer, index, count);
            }
            public override void WriteStartAttribute(string prefix, string localName, string ns)
            {
                this.inner.WriteStartAttribute(prefix, localName, ns);
            }
            public override void WriteStartDocument(bool standalone)
            {
                this.inner.WriteStartDocument(standalone);
            }
            public override void WriteStartDocument()
            {
                this.inner.WriteStartDocument();
            }
            public override void WriteStartElement(string prefix, string localName, string ns)
            {
                this.inner.WriteStartElement(prefix, localName, ns);
            }
            public override WriteState WriteState
            {
                get { return this.inner.WriteState; }
            }
            public override void WriteString(string text)
            {
                this.inner.WriteString(text);
            }
            public override void WriteSurrogateCharEntity(char lowChar, char highChar)
            {
                this.inner.WriteSurrogateCharEntity(lowChar, highChar);
            }
            public override void WriteWhitespace(string ws)
            {
                this.inner.WriteWhitespace(ws);
            }
        }
        public static void Test()
        {
            DataContractSerializer dcs = new DataContractSerializer(typeof(List<string>));
            MemoryStream ms = new MemoryStream();
            List<string> list = new List<string> { "Hello", "", "world" };
            dcs.WriteObject(ms, list);
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
            Console.WriteLine();
            ms.SetLength(0);
            XmlWriter myWriter = new MyWriter(XmlDictionaryWriter.CreateTextWriter(ms));
            dcs.WriteObject(myWriter, list);
            myWriter.Flush();
            Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
        }
    }
