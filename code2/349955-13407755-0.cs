    public class CommandExtension : MarkupExtension
    {
        public CommandExtension(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return GetBinding(this.Name).ProvideValue(serviceProvider);
        }
        static Binding GetBinding(string name)
        {
            return new Binding("Commands[" + name + "]") { Mode = BindingMode.OneWay };
        }
        public static void SetBinding(DependencyObject target, DependencyProperty dp, string commandName)
        {
            BindingOperations.SetBinding(target, dp, GetBinding(commandName));
        }
    }
