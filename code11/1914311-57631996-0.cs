C#
private static void OnIsActivatedPropertyChangedCallback(DependencyObject d, 
    DependencyPropertyChangedEventArgs e)
{
    if (!(d is TextBox)) return;
    Func<bool> tryGetBinding = () =>
    {
        // ===> Here I get null value
        var binding = BindingOperations.GetBinding(d, TextBox.TextProperty);
        if (binding == null)
            return false;
        if ((bool)e.NewValue)
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
    //  If there's no binding and it's already loaded, forget it. 
    if (!tryGetBinding() && !(d as TextBox).IsLoaded)
    {
        RoutedEventHandler onLoaded = null;
        onLoaded = (s, e2) =>
        {
            tryGetBinding();
            (d as TextBox).Loaded -= onLoaded;
        };
        (d as TextBox).Loaded += onLoaded;
    }
}
