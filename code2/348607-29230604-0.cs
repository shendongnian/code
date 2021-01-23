    [Editor(typeof(MyEditor), typeof(UITypeEditor))]
    [MyEditor.Arguments("Argument 1 value", "Argument 2 value")]
    public object Foo { get; set; }
    class MyEditor : UITypeEditor
    {
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            string property1 = string.Empty, property2 = string.Empty;
            //Get attributes with your arguments. There should be one such attribute.
            var propertyAttributes = context.PropertyDescriptor.Attributes.OfType<ArgumentsAttribute>();
            if (propertyAttributes.Count() > 0)
            {
                var argumentsAttribute = propertyAttributes.First();
                property1 = argumentsAttribute.Property1;
                property2 = argumentsAttribute.Property2;
            }
            //Do something with your properties...
            return obj;
        }
        public class ArgumentsAttribute : Attribute
        {
            public string Property1 { get; private set; }
            public string Property2 { get; private set; }
            public ArgumentsAttribute(string prop1, string prop2)
            {
                Property1 = prop1;
                Property2 = prop2;
            }
        }
    }
