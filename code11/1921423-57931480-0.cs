    public interface IBankAccountAddOnService
    {
        IBankAccountAddOnResult BuildAddOn();
    }
    public interface ICreditCardAddOnService : IBankAccountAddOnService
    {
        int CustomerId { get; }
    }
    public class CreditCardAddOnService : ICreditCardAddOnService
    {
        public CreditCardAddOnService(IExternalCreditCardService creditCardService, IRepository repository, ICreditCardAddOn creditCardAddOn)
        {
            //etc
