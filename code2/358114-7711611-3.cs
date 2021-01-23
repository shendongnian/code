         private static void OnProxyElementPropertyChanged(
             DependencyObject depObj, DependencyPropertyChangedEventArgs e)
         {
               if (depObj is ContentControl && e.NewValue is TextBlock)
               {
                   var binding = new Binding("DataContext");
                   binding.Source = depObj;
                   binding.Mode = OneWay;
                   BindingOperations.SetBinding(
                       (TextBlock)e.NewValue, TextBlock.DataContextProperty, binding);
               }
         }
