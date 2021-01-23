    public class TextBoxUpdateOnLostKeyboardFocusBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            if (AssociatedObject != null)
            {
                base.OnAttached();
                AssociatedObject.LostKeyboardFocus += OnKeyboardLostFocus;
            }
        }
        
        protected override void OnDetaching()
        {
            if (AssociatedObject != null)
            {
                AssociatedObject.LostKeyboardFocus -= OnKeyboardLostFocus;
                base.OnDetaching();
            }
        }
        private void OnKeyboardLostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                // Focus on the closest focusable ancestor
                FrameworkElement parent = (FrameworkElement) textBox.Parent;
                while (parent is IInputElement && !((IInputElement) parent).Focusable)
                {
                    parent = (FrameworkElement) parent.Parent;
                }
                DependencyObject scope = FocusManager.GetFocusScope(textBox);
                FocusManager.SetFocusedElement(scope, parent);
            }
        }
    }
