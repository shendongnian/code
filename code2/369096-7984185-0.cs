    public class MyStringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get
            {
                return null;
            }
        }
    }
