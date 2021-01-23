    public class MyMarkupExtension : MarkupExtension {
        public MyMarkupExtension() {
            this.Type = /* some default type */;
        }
        public MyMarkupExtension(Type type) {
            this.Type = type;
        }
        public Type Type { get; private set; }
        public override object ProvideValue(IServiceProvider serviceProvider) {
            Type type = typeof(MyValueConverter<>).MakeGenericType(this.Type);
            return Activator.CreateInstance(type);
        }
    }
