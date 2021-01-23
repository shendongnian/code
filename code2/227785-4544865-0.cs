    [TypeConverter(typeof(MyClassToMyExtensionConverter))]
    public sealed class MyClass { }
    
    public sealed class MyExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider sp) { return new MyClass(); }
    }
    
    public sealed class MyClassToMyExtensionConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext ctx, Type t) { return t == typeof(MarkupExtension); }
        public override object ConvertTo(ITypeDescriptorContext ctx, CultureInfo culture, object obj, Type t) { return ConvertToInternal((MyClass) obj); }
        private MyExtension ConvertToInternal(MyClass value) { return new MyExtension(); }
    }
