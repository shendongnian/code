    public interface IPremiumAccount : IAccount
    {
        public string GetAccountName(string id, string name);
    }
    public class PremiumAccount : IPremiumAccount
    {
    // ...
    IAccount a = factory.GetAccount();
    IPremiumAccount pa = a as IPremiumAccount;
    if (pa != null)
        pa.GetAccountName("X1234", "John");
