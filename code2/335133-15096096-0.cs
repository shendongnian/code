            private static void DataGridPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var fe = dependencyObject as FrameworkElement;
            var target = args.NewValue as DependencyObject;
            if (fe != null && target != null)
            {
                target.SetValue(IsFreeOfValidatoionErrorsProperty, !fe.IsVisible);
                fe.IsVisibleChanged += (_1, _) =>
                {
                    target.SetValue(IsFreeOfValidatoionErrorsProperty, !fe.IsVisible);
                };
                
            }
