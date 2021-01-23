    [AttributeUsage(AttributeTargets.Parameter, 
     AllowMultiple = false, Inherited = false)]
    public abstract class ValidateParameterAttribute : Attribute
    {
      private bool _continueValidation = false;
      
      public bool ContinueValidation 
      { get { return _continueValidation; } set { _continueValidation = value; } }
      private int _order = -1;
      public int Order { get { return _order; } set { _order = value; } }
      public abstract bool Validate
        (ControllerContext context, ParameterDescriptor parameter, object value);
      public abstract ModelError CreateModelError
        (ControllerContext context, ParameterDescriptor parameter, object value);
      public virtual ModelError GetModelError
        (ControllerContext context, ParameterDescriptor parameter, object value)
      {
        if (!Validate(context, parameter, value))
          return CreateModelError(context, parameter, value);
        return null;
      }
    }
    [AttributeUsage(AttributeTargets.Parameter, 
     AllowMultiple = false, Inherited = false)]
    public class RequiredParameterAttribute : ValidateParameterAttribute
    {
      private object _missing = null;
      public object MissingValue 
        { get { return _missing; } set { _missing = value; } }
      public virtual object GetMissingValue
        (ControllerContext context, ParameterDescriptor parameter)
      {
        //using a virtual method so that a missing value could be selected based
        //on the current controller's state.
        return MissingValue;
      }
      public override bool Validate
        (ControllerContext context, ParameterDescriptor parameter, object value)
      {
        return !object.Equals(value, GetMissingValue(context, parameter));
      }
      public override ModelError CreateModelError
        (ControllerContext context, ParameterDescriptor parameter, object value)
      {
        return new ModelError(
          string.Format("Parameter {0} is required", parameter.ParameterName));
      }
    }
