    namespace MyApplication.Controls
    {
        using System;
        using System.Collections;
        using System.ComponentModel;
        using System.Linq;
        using System.Windows;
        using System.Windows.Controls;
        using System.Windows.Data;
    
        public abstract class ControlBaseWithValidation : Control, INotifyDataErrorInfo
        {
            public ControlBaseWithValidation()
            {
                // remove the red border that wraps the whole control by default
                Validation.SetErrorTemplate(this, null);
            }
    
            public delegate void ErrorsChangedEventHandler(object sender, DataErrorsChangedEventArgs e);
    
            public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
    
            public bool HasErrors
            {
                get
                {
                    var validationErrors = Validation.GetErrors(this);
                    return validationErrors.Any();
                }
            }
    
            public IEnumerable GetErrors(string propertyName)
            {
                var validationErrors = Validation.GetErrors(this);
                var specificValidationErrors =
                    validationErrors.Where(
                        error => ((BindingExpression)error.BindingInError).TargetProperty.Name == propertyName).ToList();
                var specificValidationErrorMessages = specificValidationErrors.Select(valError => valError.ErrorContent);
                return specificValidationErrorMessages;
            }
    
            public void NotifyErrorsChanged(string propertyName)
            {
                if (ErrorsChanged != null)
                {
                    ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
                }
            }
    
            protected static void ValidatePropertyWhenChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
            {
                ((ControlBaseWithValidation)dependencyObject).NotifyErrorsChanged(dependencyPropertyChangedEventArgs.Property.Name);
            }
        }
    }
