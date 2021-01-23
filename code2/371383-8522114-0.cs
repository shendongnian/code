    public class NullableDecimalConverter : FileHelpers.ConverterBase
    {
        public override object StringToField(string from)
        {
            return from;
        }
        public override string FieldToString(object fieldValue)
        {
            if (fieldValue == null)
                return String.Empty;
            return fieldValue.ToString();
        }
    }
