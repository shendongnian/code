    public abstract class ValidationAttribute<T> : Attribute
    {
         public abstract bool IsValid(T value);
    }
    public class EvenValidation : ValidationAttribute<int>
    {
         public override bool IsValid(int value)
         {
              return value % 2 == 0;
         }
    }
    public interface IFoo
    {
         [EvenValidation]
         int SomeValue { get; }
    }
    public class Validator
    {
          public bool IsValid(object component, object proposedValue, string property) 
          {
               //Use reflection to look for ValidationAttributes on the property
               //Use the ValidationAttribute to validate the proposed value
          }
    }
