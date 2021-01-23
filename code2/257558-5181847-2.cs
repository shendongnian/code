    // this defines a custom type converter to convert from an IBenchmark to a string
    // used by the property grid to display item when non edited
    public class BenchmarkTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            // we only know how to convert from to a string
            return typeof(string) == destinationType;
        }
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (typeof(string) == destinationType)
            {
                // just use the benchmark name
                IBenchmark benchmark = value as IBenchmark;
                if (benchmark != null)
                    return benchmark.Name;
            }
            return "(none)";
        }
    }
