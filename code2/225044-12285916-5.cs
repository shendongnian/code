        public class BindingHelper: FrameworkElement
        {
           public static void SetSource(object source, Binding binding, object value)
           {
               var fe = new BindingHelper();
               var newBinding = new Binding(binding.Path.Path)
               {
                   Mode = BindingMode.OneWayToSource,
                   Source = source,
               };
               fe.SetBinding(ValueProperty, newBinding);
               fe.Value = value;
            }
            #region Value Dependency Property
            public object Value
            {
                get { return (object)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
            public static readonly DependencyProperty ValueProperty =
               DependencyProperty.Register("Value", typeof(object), typeof(BindingHelper));
            #endregion
        }
