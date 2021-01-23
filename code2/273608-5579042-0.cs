    public interface X {}
    
    public class Car : X {}
    
    public class User : X {}
    
    public static class Xtensions
    {
       public static Xtension( this X target ) {}
    }
