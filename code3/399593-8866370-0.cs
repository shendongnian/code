    public class EntitizingXmlWriter : XmlTextWriter
    {
        public EntitizingXmlWriter(TextWriter writer) :
            base(writer)
        { }
        public override void WriteString(string text)
        {
            foreach (char c in text)
            {
                switch (c)
                {
                    case '\r':
                    case '\n':
                    case '\t':
                        base.WriteCharEntity(c);
                        break;
                    default:
                        base.WriteString(c.ToString());
                        break;
                }
            }
        }
    }
