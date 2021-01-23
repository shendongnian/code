    public interface IRegisterable
    {
        // ... something makes me registerable....
    }
    
    public class User : IRegisterable
    {
    }
    
    public class Register
    {
       public void Register(IRegisterable item) { }
    }
