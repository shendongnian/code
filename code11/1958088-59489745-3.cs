     public static class Attach
    {
        public static BindableProperty IsFocusedProperty = BindableProperty.Create("IsFocused", typeof(bool), typeof(Attach), false, propertyChanged: OnIsFocusedChanged);
        public static void OnIsFocusedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = bindable as UITextField;
            if(newValue) textField.Focus();
        }
    }
