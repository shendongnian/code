    [ServiceContract]
    public interface IService
    {
       [OperationContract]
       AccountDTO GetAccount(int accountId);
    }
     [DataContract]
     public class AccountDTO
     {
      [DataMember]
      public string AccountNo { get; set; }
      [DataMember]
      public string AccountName { get; set; }
     }
     public class Service : IService
     {
       // Define a Factory in your .svc file to inject a repository implementation.
       // It's best to use an IoC container like Ninject for this sort of thing.
       public Service( // no pun intended
           IAccountRepository accountRepository)
       {
         _accountRepository = accountRepository
       }
       public AccountDTO GetAccount(int accountId)
       {
         Mapper.CreateMap<Account, AccountDTO>();
         var account = _accountRepository.GetAccount(accountId);
         var accountDto = Mapper.Map<Account, AccountDTO>(account);
         return account;
       }
     }
