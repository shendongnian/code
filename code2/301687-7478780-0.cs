    public class ValidationSummaryCountFixBehavior : Behavior<ValidationSummary>
    {
        private Dictionary<string, ValidationSummaryItem> _validationErrors = new Dictionary<string, ValidationSummaryItem>();
    
        protected override void OnAttached()
        {
            base.OnAttached();
    
            AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);
        }
    
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            var target = AssociatedObject.Target as FrameworkElement ?? VisualTreeHelper.GetParent(AssociatedObject) as FrameworkElement;
            if (target != null)
            {
                target.BindingValidationError += new EventHandler<ValidationErrorEventArgs>(target_BindingValidationError);
            }
            AssociatedObject.Loaded -= new RoutedEventHandler(AssociatedObject_Loaded);
        }
    
        void target_BindingValidationError(object sender, ValidationErrorEventArgs e)
        {
            FrameworkElement inputControl = e.OriginalSource as FrameworkElement;
    
            if (((e != null) && (e.Error != null)) && ((e.Error.ErrorContent != null) && (inputControl != null)))
            {
                string message = e.Error.ErrorContent.ToString();
                string goodkey = inputControl.GetHashCode().ToString(CultureInfo.InvariantCulture);
                goodkey = goodkey + message;
    
                if (e.Action == ValidationErrorEventAction.Added && ValidationSummary.GetShowErrorsInSummary(inputControl))
                {
                    string messageHeader = null;
                    ValidationSummaryItem item = new ValidationSummaryItem(message, messageHeader, ValidationSummaryItemType.PropertyError, new ValidationSummaryItemSource(messageHeader, inputControl as Control), null);
                    _validationErrors[goodkey] = item;
                }
                else
                {
                    _validationErrors.Remove(goodkey);
                }
            }
    
            UpdateDisplayedErrors();
        }
    
        private void UpdateDisplayedErrors()
        {
            AssociatedObject.Errors.Clear();
            foreach (ValidationSummaryItem item in _validationErrors.Values)
            {
                AssociatedObject.Errors.Add(item);
            }
        }
    }
