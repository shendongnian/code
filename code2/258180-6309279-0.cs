    public class MyCustomSelect : TypeConverter
    {
        public override bool
        GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true; // display drop
        }
        public override bool
        GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true; // drop-down vs combo
        }
        public override StandardValuesCollection
        GetStandardValues(ITypeDescriptorContext context)
        {
            // can look at context to build list, if necessary
            return new StandardValuesCollection(new string[] { "abc", "def", "ghi" });
        }
    }
