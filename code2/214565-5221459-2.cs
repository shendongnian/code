    public object Value
    {
       get { return (object)GetValue(ValueProperty); }
       set 
       {
          if (value.ToString() == "testing")
          {
              SetControlError(this, "This is an invalid value.");
          }
          else
          {
              ClearControlError(this);
              SetValue(ValueProperty, value);
          }
       }
    }
   
    public void ClearControlError(Control control)
    {
       BindingExpression b = control.GetBindingExpression(Control.TagProperty);
       if (b != null)
       {
          ((ControlValidationHelper)b.DataItem).ThrowValidationError = false;
          b.UpdateSource();
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
