    public class MyXmlWriter : XmlTextWriter
    {
        public override void WriteEndElement()
        {
            // this should do the trick
            WriteFullEndElement();
        }
    }
