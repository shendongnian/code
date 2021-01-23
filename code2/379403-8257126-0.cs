    public interface INameable
    {
       String Name { get; }
    }
    
    public static String GetAString(INameable nameable)
    {
       return nameable.Name;
    }
