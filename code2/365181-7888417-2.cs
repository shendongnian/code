    interface IBaseExternalDepositResult
    {
    };  // eo interface BaseExternalDepositResult
    interface IDeposit
    {
        void Deposit();
    };
    // class BaseExternalDeposit<>
    abstract class BaseExternalDeposit<B> : IDeposit where B : BaseDepositStructure
    {
        private B depositStructure_;
        protected abstract IBaseExternalDepositResult DepositImpl();
        protected B Structure { get { return depositStructure_; } }
        public BaseExternalDeposit(B depositStructure)
        {
            depositStructure_ = depositStructure;
        }   // eo ctor
        // IDeposit
        void Deposit()
        {
            DepositImpl();
        }
    }   // eo class BaseExternalDeposit<B>
    // class SafeChargeDeposit
    class SafeChargeDeposit : BaseExternalDeposit<CreditCardDepositStructure>
    {
        protected override IBaseExternalDepositResult DepositImpl()
        {
            Structure.Amount = 50;
            Structure.CreditCardNumber = "123456";
        }   // eo DepositImpl
        public SafeChargeDeposit(CreditCardDepositStructure depositStructure)
            : base(depositStructure)
        {
        }
    }   // eo class SafeChargeDeposit
    public class BaseDepositStructure
    {
        public double Amount = 0.0;
    }
    public class CreditCardDepositStructure : BaseDepositStructure
    {
        public string CreditCardNumber = string.E
