    public class SomeExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provider =     serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var target = provider.TargetObject as DependencyObject;
            var property = provider.TargetProperty as DependencyProperty;
            // defer execution if target is data template
            if (target == null)
               return this;
            return SomeMethod(target, property);
        }
    
        public object SomeMethod(DependencyObject target, DependencyProperty property)
        {
            ... // do something
        }
    }
