    [ServiceContract]
    public interface IService
    {
       [OperationContract]
       AccountDTO GetAccount();
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
       public AccountDTO GetAccount()
       {
        AccountBLL bll = new AccountBLL();
        Mapper.CreateMap<Account, AccountDTO>();
        var account = Mapper.Map<Account, AccountDTO>(bll.GetAccount());
        return account;
       }
      }
