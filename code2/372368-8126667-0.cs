    public class TextBoxProperties
    {
        public static readonly DependencyProperty EnterUpdatesTextSourceProperty =
            DependencyProperty.RegisterAttached("EnterUpdatesTextSource", typeof(bool), typeof(TextBoxProperties), 
                new PropertyMetadata(false, EnterUpdatesTextSourcePropertyChanged));
        // Get
        public static bool GetEnterUpdatesTextSource(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnterUpdatesTextSourceProperty);
        }
        // Set
        public static void SetEnterUpdatesTextSource(DependencyObject obj, bool value)
        {
            obj.SetValue(EnterUpdatesTextSourceProperty, value);
        }
        // Changed Event - Attach PreviewKeyDown handler
        private static void EnterUpdatesTextSourcePropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var sender = obj as UIElement;
            if (obj != null)
            {
                if ((bool)e.NewValue)
                {
                    sender.PreviewKeyDown += OnPreviewKeyDown_UpdateSourceIfEnter;
                }
                else
                {
                    sender.PreviewKeyDown -= OnPreviewKeyDown_UpdateSourceIfEnter;
                }
            }
        }
        // If key being pressed is the Enter key, and EnterUpdatesTextSource is set to true, then update source for Text property
        private static void OnPreviewKeyDown_UpdateSourceIfEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (GetEnterUpdatesTextSource((DependencyObject)sender))
                {
                    var obj = sender as UIElement;
                    BindingExpression textBinding = BindingOperations.GetBindingExpression(
                        obj, TextBox.TextProperty);
                    if (textBinding != null)
                        textBinding.UpdateSource();
                }
            }
        }
    }
