    //Let's call the interface IIDInterface
    public interface IIDInterface
    {
        int Id { get; }
    }
    // Now, suppose one of your entity classes is called: EntityOne
    public class EntityOne : IIDInterface            
    {
        // .. class constructors etc.
        // the IIDInterface interface method implementation
        public int Id
        {
            get
            {
                // getter implementation goes here
            }
        }
        // .. other members of the class
    }
