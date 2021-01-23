    public class MyXmlTextWriter : XmlTextWriter
    {
        public MyXmlTextWriter(TextWriter textWriter) : base(textWriter) { }
        public MyXmlTextWriter(Stream stream, Encoding encoding) : base(stream, encoding) { }
        public MyXmlTextWriter(string filename, Encoding encoding) : base(filename, encoding) { }
        public override void WriteString(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return;
            }
    
            // WriteString will happily escape any XML markup characters. However, 
            // for legibility we write content that contains certain special
            // characters as CDATA 
            const string SpecialChars = @"<>&";
            if (text.IndexOfAny(SpecialChars.ToCharArray()) != -1)
            {
                WriteCData(text);
            }
            else
            {
                base.WriteString(text);
            }
        }
    }
