    [TypeConverter(typeof(MyControlFactoryConverter))]
    public class MyControl : Control {
        public string Parameter { get; private set; }
        public MyControl() { }
        public MyControl(string parameter) {
            Parameter = parameter;
        }
    }
    public static class MyControlFactory {
        public static MyControl CreateControl(string parameter) {
            return new MyControl(parameter);
        }
    }
    //
    public class MyControlFactoryConverter : ExpandableObjectConverter {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) {
            if(destinationType == typeof(InstanceDescriptor)) return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType) {
            if(destinationType == typeof(InstanceDescriptor) && value != null) {
                MethodInfo mInfo = typeof(MyControlFactory).GetMethod("CreateControl",
                    BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
                return new InstanceDescriptor(mInfo, new object[] { "Hello World" });
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
