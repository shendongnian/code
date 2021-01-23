    public abstract class ValidationAttribute : Attribute
    {
        public abstract bool IsValid(object value);
    }
    
    public class EvenValidation : ValidationAttribute
    {
         public override bool IsValid(object value)
         {  
              if (!(value is int))
                 return false;
              return ((int)value) % 2 == 0;
         }
    }
    public interface IFoo
    {
         [EvenValidation]
         int SomeValue { get; }
    }
    public static class Validator
    {
          public static bool IsValid(object component, object proposedValue, string property) 
          {
               //Use reflection to look for ValidationAttributes on the property
               //Use the ValidationAttribute to validate the proposed value
          }
    }
