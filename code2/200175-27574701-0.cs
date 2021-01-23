    using System.Xaml;
    using System.Windows.Markup;
    public sealed class XamlRootExtension : MarkupExtension
    {
        public override Object ProvideValue(IServiceProvider sp)
        {
            var rop = sp.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;
            return rop == null ? null : rop.RootObject;
        }
    };
