    public class BaseMessage { }
    public class OtherMessage : BaseMessage { }
    private BaseMessage getMessage()
    {
        return new OtherMessage();
    }
    
    private void CheckType<T>(T type)
    {
        Console.WriteLine(type.GetType().ToString());   // prints OtherMessage
        Console.WriteLine(typeof(T).ToString());        // prints BaseMessage
    }
    
    private void DoChecks()
    {
         BaseMessage mess = getMessage();
         CheckType(mess);
    }
