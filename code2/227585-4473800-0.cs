    public interface IMailingListService
    {
      void Subscribe(string email);
      void Unsubscribe(string email);
    }
    
    public interface IMailingListRepository
    {
      MailingList LoadMailingList();
      void SaveMailingList(MailingList list);
    }
    
    public class MailingListService: IMailingListService
    {
      private IMailingListRepository _repository;
    
      public MailingList(IMailingListRepository repository)
      {
        _repository = repository;
      }
    
      public void Subscribe(string email)
      {
        var list = _repository.LoadMailingList();
        list.Subscribe(email);
        _repository.SaveMailingList(list); 
      }
    }
