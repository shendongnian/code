    class XmlEntityResolver : XmlResolver {
        public override object GetEntity(Uri absoluteUri,
                                         string role,
                                         Type ofObjectToReturn) 
        {
            if (absoluteUri.toString() == "-//MY PUB ID") {
                MemoryStream ms = new MemoryStream();
                StreamWriter sw = new StreamWriter(ms);
                sw.Write("<!ENTITY rsquo \"'\">");
                sw.Flush();
                ms.Position = 0;
                return ms;
            }
            else {
                return base.GetEntity(absoluteUri, role, ofObjectToReturn);
            }
        }
    }
