    public class TextBoxHelper
    {
        // I excluded the generic stuff, but the property is called 
        // EnterUpdatesSource and it makes a TextBox update it's source
        // whenever the Enter key is pressed
        // Property Changed Event - You have this in your class above
        private static void EnterUpdatesTextSourcePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            UIElement sender = obj as UIElement;
            if (obj != null)
            {
                // In my case, the True/False value just determined a behavior,
                // so toggling true/false added/removed an event.
                // Since you want your events to be on at all times, you'll either
                // want to have two AttachedProperties (one to tell the control
                // that it should be tracking the current focused state, and 
                // another for binding the actual focused state), or you'll want 
                // to find a way to only add the EventHandler when the 
                // AttachedProperty is first added and not toggle it on/off as focus 
                // changes or add it repeatedly whenever this value is set to true
                // You can use the GotFocus and LostFocus Events
                if ((bool)e.NewValue == true)
                {
                    sender.PreviewKeyDown += new KeyEventHandler(OnPreviewKeyDownUpdateSourceIfEnter);
                }
                else
                {
                    sender.PreviewKeyDown -= OnPreviewKeyDownUpdateSourceIfEnter;
                }
            }
        }
        // This is the EventHandler
        static void OnPreviewKeyDownUpdateSourceIfEnter(object sender, KeyEventArgs e)
        {
            // You won't need this
            if (e.Key == Key.Enter)
            {
                // or this
                if (GetEnterUpdatesTextSource((DependencyObject)sender))
                {
                    // But you'll want to take this bit and modify it so it actually 
                    // provides a value to the Source based on UIElement.IsFocused
                    UIElement obj = sender as UIElement;
                    // If you go with two AttachedProperties, this binding should 
                    // point to the property that contains the IsFocused value
                    BindingExpression textBinding = BindingOperations.GetBindingExpression(
                        obj, TextBox.TextProperty);
                    // I know you can specify a value for a binding source, but
                    // I can't remember the exact syntax for it right now
                    if (textBinding != null)
                        textBinding.UpdateSource();
                }
            }
        }
