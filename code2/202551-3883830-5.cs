     namespace BLL
     {
       // This defines the repository interface.
       public interface IAccountRepository
       {
         Account GetAccount(int accountId);
       }
       public class AccountRepository
       {
         public Account GetAccount(int accountId) {
           // get the Account object from the data layer.
         }
       }
       // Using an interface makes it easy to swap various implementations.
       // The implementation above would be the one you'd normally use, but you could
       // create others like this to help with unit testing and such.
       public class FakeAccountRepository : IAccountRepository
       {
        public Account GetAccount(int accountId)
        {
            return new Account { AccountName = "JuanDeLaCruz", AccountNo = "123456" };
        }
       }
     }
