    public class MyXmlWriter : XmlTextWriter
    {
        // …constructors etc. omitted for the sake of simplicity…
        public override void WriteEndElement()
        {
            // this should do the trick
            WriteFullEndElement();
        }
    }
