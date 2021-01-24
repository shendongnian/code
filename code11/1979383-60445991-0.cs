    public interface ICommand
    {
    
       IEnumerable<IMessage> Do();
    }
    public class ProcessTagICommand : ICommand
    {
    
       public IEnumerable<IMessage> Do()
       {
          return new List<QuoteMessage>();
       }
    }
