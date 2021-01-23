    public interface IListener
    {
    void MessageRaised(int messageId, params object[] arguments);
    }
    
    public class Mediator
    {
    public void Register(IListener listener, int messageId)
    {
    //... add to dictionary of arrays for each messageId
    }
    
    public void NotifyListeners(int messageId, params object[] arguments)
    {
    //... loop through listeners for the messageId and call the MessageRaised function for each one
    }
    }
