    public class Order
    {
    [System.ComponentModel.DataAnnotations.Required( AllowEmptyStrings = false )]
    public string Name
    {
      get;
      set;
    }
    [System.ComponentModel.DataAnnotations.CustomValidation( typeof( Order ), "ValidateOrderLines" )]
    public BindingList<OrderDetail> Lines
    {
      get;
      set;
    }
    public static ValidationResult ValidateOrderLines( Order order, ValidationContext validationContext )
    {
      ValidationResult result = new ValidationResult( "Lines are required!" );
      if ( order.Lines.Count != 0 )
        result = ValidationResult.Success;
      return result;
    }
