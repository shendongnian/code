    public class MyBoundField : BoundField
    {
       protected override object GetValue(Control controlContainer)
       {
          string dataField = this.DataField;
          if (string.IsNullOrEmpty(dataField)) { return null; }
          if (!dataField.Contains('.'))
          {
             // use base implemenation
             return base.GetValue(controlContainer);
          }
    
          // design time support
          if (base.DesignMode)
          {
            return this.GetDesignTimeValue();
          }
    
          // Use data-binder to evaluate nested property look-ups
          return DataBinder.Eval(controlContainer, dataField);
       }
    
    }
