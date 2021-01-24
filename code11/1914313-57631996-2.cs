C#
private static void OnIsActivatedPropertyChangedCallback(DependencyObject d,
    DependencyPropertyChangedEventArgs e)
{
    if (d is TextBox textBox)
    {
        if (!tryGetBinding() && !textBox.IsLoaded)
        {
            void onLoaded(object sender, RoutedEventArgs e2)
            {
                tryGetBinding();
                textBox.Loaded -= onLoaded;
            };
            textBox.Loaded += onLoaded;
        }
        bool tryGetBinding()
        {
            // ===> Here I get null value
            var binding = BindingOperations.GetBinding(textBox, TextBox.TextProperty);
            if (binding == null)
                return false;
            if (GetIsActivated(textBox))
            {
                var sourceObject = binding.Path.Path;
                //Doing some stuff...
            }
            else
            {
                //Doing some stuff...
            }
            return true;
        };
    }
}
