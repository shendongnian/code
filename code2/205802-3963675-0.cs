    public class MVVMViewBase : UserControl
        {
            private RoutedEventHandler _errorEventRoutedEventHandler;
            public MVVMViewBase()
            {
                Loaded += (s, e) =>
                    {
                        _errorEventRoutedEventHandler = new RoutedEventHandler(ExceptionValidationErrorHandler);
                        AddHandler(Validation.ErrorEvent, _errorEventRoutedEventHandler);
                    };
    
                Unloaded += (s, e) =>
                    {
                        if (_errorEventRoutedEventHandler != null)
                        {
                            RemoveHandler(Validation.ErrorEvent, _errorEventRoutedEventHandler);
                            _errorEventRoutedEventHandler = null;
                        }
                    };
            }
    
            private void ExceptionValidationErrorHandler(object sender, RoutedEventArgs e)
            {
                ValidationErrorEventArgs args = (ValidationErrorEventArgs) e;
                if (!(args.Error.RuleInError is IUiValidation)) return;
    
                DataErrorInfoViewModelBase viewModelBase = DataContext as DataErrorInfoViewModelBase;
                if(viewModelBase == null) return;
    
                BindingExpression bindingExpression = (BindingExpression) args.Error.BindingInError;
                string dataItemName = bindingExpression.DataItem.ToString();
                string propertyName = bindingExpression.ParentBinding.Path.Path;
    
                e.Handled = true;
                if(args.Action == ValidationErrorEventAction.Removed)
                {
                    viewModelBase.RemoveUIValidationError(new UiValidationError(dataItemName, propertyName, null));
                    return;
                }
    
                string validationErrorText = string.Empty;
                foreach(ValidationError validationError in Validation.GetErrors((DependencyObject) args.OriginalSource))
                {
                    if (validationError.RuleInError is IUiValidation)
                    {
                        validationErrorText = validationError.ErrorContent.ToString();
                    }
                }
                viewModelBase.AddUIValidationError(new UiValidationError(dataItemName, propertyName, validationErrorText));
            }
        }
