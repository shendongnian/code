    public class PdfSignerNoObjectStream : PdfSigner
    {
        public PdfSignerNoObjectStream(PdfReader reader, Stream outputStream, StampingProperties properties) : base(reader, outputStream, properties)
        {
        }
        protected override PdfDocument InitDocument(PdfReader reader, PdfWriter writer, StampingProperties properties)
        {
            try
            {
                return base.InitDocument(reader, writer, properties);
            }
            finally
            {
                FieldInfo propertiesField = typeof(PdfWriter).GetField("properties", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                WriterProperties writerProperties = (WriterProperties) propertiesField.GetValue(writer);
                writerProperties.SetFullCompressionMode(false);
            }
        }
    }
