    public object Value
    {
       get { return (object)GetValue(ValueProperty); }
       set 
       {
          if (value.ToString() == "testing")
          {
              SetControlError(this, "This is an invalid value.");
              VisualStateManager.GoToState(this, "InvalidFocus", true);
          }
          else
          {
              VisualStateManager.GoToState(this, "Valid", true);
              SetValue(ValueProperty, value);
          }
       }
    }
       
     public void SetControlError(Control control, string errorMessage)
     {
        ControlValidationHelper validationHelper =
                    new ControlValidationHelper(errorMessage);
    
        control.SetBinding(Control.TagProperty, new Binding("ValidationError")
        {
           Mode = BindingMode.TwoWay,
           NotifyOnValidationError = true,
           ValidatesOnExceptions = true,
           UpdateSourceTrigger = UpdateSourceTrigger.Explicit,
           Source = validationHelper
        });
    
        // this line throws a ValidationException with your custom error message;
        // the control will catch this exception and switch to its "invalid" state
        control.GetBindingExpression(Control.TagProperty).UpdateSource();
    }
