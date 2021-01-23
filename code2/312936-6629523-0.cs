    private void mycontrol_LostFocus(object sender, RoutedEventArgs e)
    {
        if (mycontrol.IsModified)
        {
            var binding = mycontrol.GetBindingExpression(MyControl.FooBarProperty);
            binding.UpdateSource();
        }
    }
