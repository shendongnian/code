     public class InvalidMyClassInputException : ApplicationException
     {
          public InvalidMyClassInputException(object obj)
             : base("An invalid call to DoSomething was made with object of type: " + obj.GetType().Name)
          {
          }
     }
