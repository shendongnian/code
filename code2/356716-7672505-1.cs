    public interface ISpecification { bool Check(object some); }
    
    public class Person { public string Name { get; set; } }
    
    public class PersonSpecification : ISpecification
    {
         public bool Check(object some) 
         {
              // Checks that some person won't be null and his/her name isn't null or empty
              return some != null && !string.IsNullOrEmpty(((Person)some).Name);
         }
    } 
