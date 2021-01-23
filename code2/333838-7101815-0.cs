    public class DataBinder
    {
        private static readonly DependencyProperty BindingEvalProperty = DependencyProperty.RegisterAttached(
            "BindingEval",
            typeof(Object),
            typeof(DependencyObject),
            new UIPropertyMetadata(null));
    
        public static Object Eval(Object data, Binding binding)
        {
            var newbinding = new Binding {Path = binding.Path, Converter = binding.Converter, Source = data};
            var evalobj = new DependencyObject();
            BindingOperations.SetBinding(evalobj, BindingEvalProperty, newbinding);
            return evalobj.GetValue(BindingEvalProperty);
        }
    }
