    public class Iso8583Extended : Iso8583Rev93
    {
        private static readonly Template ExtendedTemplate;
        static Iso8583Extended()
        {
            ExtendedTemplate = new Template();
            ExtendedTemplate[Bit._128_MAC] = FieldDescriptor.AsciiFixed(16, FieldValidators.Hex);
        }
        public Iso8583Extended():base(ExtendedTemplate)
        {
        }
    }
