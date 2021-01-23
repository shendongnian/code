    public class EnumToIntExtension : MarkupExtension
    {
        public object EnumValue
        {
            get;
            set;
        }
        public EnumToIntExtension(object enumValue)
        {
            this.EnumValue = enumValue;
        } 
        public override object ProvideValue(IServiceProvider provider)
        {
            if (EnumValue != null && EnumValue is Enum)
            {
                return System.Convert.ToInt32(EnumValue);
            }
            return -1;
        }
    }
