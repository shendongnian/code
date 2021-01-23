    public static class ChildValidationBehavior 
    {
        private static readonly DependencyProperty ErrorCountProperty =
            DependencyProperty.RegisterAttached("ErrorCount",
                                                typeof(int),
                                                typeof(ChildValidationBehavior));
        private static void SetErrorCount(DependencyObject element, int value)
        {
            element.SetValue(ErrorCountProperty, value);
        }
        private static int GetErrorCount(DependencyObject element)
        {
            return (int)element.GetValue(ErrorCountProperty);
        }
        public static readonly DependencyProperty ChildValidationProperty = 
            DependencyProperty.RegisterAttached("ChildValidation", 
                                                typeof(bool),
                                                typeof(ChildValidationBehavior),
                                                new UIPropertyMetadata(false, OnChildValidationPropertyChanged));
        public static bool GetChildValidation(DependencyObject obj) 
        {
            return (bool)obj.GetValue(ChildValidationProperty); 
        }
        public static void SetChildValidation(DependencyObject obj, bool value) 
        {
            obj.SetValue(ChildValidationProperty, value); 
        }
        private static void OnChildValidationPropertyChanged(DependencyObject dpo, 
                                                             DependencyPropertyChangedEventArgs e)
        {
            Control control = dpo as Control;
            if (control != null)
            { 
                if ((bool)e.NewValue == true) 
                {
                    SetErrorCount(control, 0);
                    Validation.AddErrorHandler(control, Validation_Error);
                } 
                else 
                {
                    Validation.RemoveErrorHandler(control, Validation_Error);
                } 
            } 
        }
        private static void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            Control control = sender as Control;
            if (e.Action == ValidationErrorEventAction.Added)
            {
                SetErrorCount(control, GetErrorCount(control)+1);
            }
            else
            {
                SetErrorCount(control, GetErrorCount(control)-1);
            }
            int errorCount = GetErrorCount(control);
            if (errorCount > 0)
            {
                control.BorderBrush = Brushes.Red;
            }
            else
            {
                control.ClearValue(Control.BorderBrushProperty);
            }
        }
    }
