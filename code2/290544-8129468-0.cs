    public abstract class AccountBaseTest
    {
        protected abstract IAccountRepository GetAccountRepository();
    
        public void _submitAccountToLMS_BlankAccount_NewLmsID()
        {
           Account account = new Account(GetAccountRepository());
           account.FirstName = Faker.FirstName();
           account.LastName = Faker.LastName();
           account.SubmitToLms();
           Assert.IsTrue(account.LmsID > 0);
        }
    }
    [TestClass]
    public class AccountIntegrationTest
    {
        protected override IAccountRepository GetAccountRepository()
        {
            return new AccountRepository();
        }
    
        [TestMethod]
        public void SubmitAccountToLMS_BlankAccount_NewLmsID()
        {
           base._submitAccountToLMS_BlankAccount_NewLmsID();
        }
    }
