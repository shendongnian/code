    public class EmptyStringConverter : ConverterBase
    {
        public override object StringToField(string sourceString)
        {
            if (String.IsNullOrWhiteSpace(sourceString))
                return null;
            return sourceString;
        }
    }
