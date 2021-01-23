    public static class BindingHelperBehavior
    {
        private static readonly DependencyProperty BindingHelperProperty =
            DependencyProperty.RegisterAttached("BindingHelper",
                                                typeof(BindingInfo),
                                                typeof(BindingHelperBehavior),
                                                new PropertyMetadata(null, OnBindingHelperPropertyChanged));
        public static void SetBindingHelper(DependencyObject element, BindingInfo value)
        {
            element.SetValue(BindingHelperProperty, value);
        }
        public static BindingInfo GetBindingHelper(DependencyObject element)
        {
            return (BindingInfo)element.GetValue(BindingHelperProperty);
        }
        
        private static void OnBindingHelperPropertyChanged(DependencyObject dpo,
                                                           DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = dpo as FrameworkElement;
            BindingInfo bindingInfo = e.NewValue as BindingInfo;
            DependencyProperty dp = (DependencyProperty)dpo.GetType().GetField(bindingInfo.PropertyName + "Property").GetValue(dpo);
            //BindingOperations.SetBinding(dpo, dp, bindingInfo.Binding); // => Exception
            RoutedEventHandler loadedEventHandler = null;
            loadedEventHandler = new RoutedEventHandler(delegate
            {
                frameworkElement.Loaded -= loadedEventHandler;
                BindingOperations.SetBinding(dpo, dp, bindingInfo.Binding);
            });
            frameworkElement.Loaded += loadedEventHandler;
            // To just use this for ListPicker / SelectedItem
            //ListPicker listPicker = dpo as ListPicker;
            //BindingInfo bindingInfo = e.NewValue as BindingInfo;
            //DependencyProperty dp = (DependencyProperty)typeof(ListPicker).GetField(bindingInfo.PropertyName + "Property").GetValue(listPicker);
            //listPicker.SelectedItem = "sunday";             // => Exception
            //listPicker.SetBinding(dp, bindingInfo.Binding); // => Exception
            
            //RoutedEventHandler loadedEventHandler = null;
            //loadedEventHandler = new RoutedEventHandler(delegate
            //{
            //    listPicker.Loaded -= loadedEventHandler;
            //    listPicker.SetBinding(dp, bindingInfo.Binding);
            //});
            //listPicker.Loaded += loadedEventHandler;
        }
    }
