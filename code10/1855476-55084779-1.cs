    class Program
    {
        static void Main(string[] args)
        {
            var mock = new MockMessagePrinter();
            ATMCustomer atmCustomer = new ATMCustomer(mock, new RepoTransaction());
            atmCustomer.PlaceDeposit(new BankAccount(), 0);
            Console.WriteLine(mock.Message == "Amount needs to be more than zero. Try again.");
            Console.ReadLine();
        }
    }
    public class ATMCustomer
    {
        private readonly IMessagePrinter _msgPrinter;
        private readonly IRepoTransaction _repoTransaction;
        public ATMCustomer(IMessagePrinter msgPrinter, IRepoTransaction repoTransaction)
        {
            _msgPrinter = msgPrinter;
            _repoTransaction = repoTransaction;
        }
        public void PlaceDeposit(BankAccount account, decimal _transaction_amt)
        {
            if (_transaction_amt <= 0)
                _msgPrinter.PrintMessage("Amount needs to be more than zero. Try again.", false);
            else if (_transaction_amt % 10 != 0)
                _msgPrinter.PrintMessage($"Key in the deposit amount only with multiply of 10. Try again.", false);
            else if (!PreviewBankNotesCount(_transaction_amt))
                _msgPrinter.PrintMessage($"You have cancelled your action.", false);
            else
            {
                // Bind transaction_amt to Transaction object
                // Add transaction record - Start
                var transaction = new Transaction()
                {
                    AccountID = account.Id,
                    BankAccountNoTo = account.AccountNumber,
                    TransactionType = TransactionType.Deposit,
                    TransactionAmount = _transaction_amt,
                    TransactionDate = DateTime.Now
                };
                _repoTransaction.InsertTransaction(transaction);
                // Add transaction record - End
                account.Balance = account.Balance + _transaction_amt;
                //ctx.SaveChanges();
                //_msgPrinter.PrintMessage($"You have successfully deposited {Utility.FormatAmount(_transaction_amt)}", true);
            }
        }
        private bool PreviewBankNotesCount(decimal transactionAmt)
        {
            throw new NotImplementedException();
        }
    }
    public class MockMessagePrinter : IMessagePrinter
    {
        private string _message;
        public string Message => _message;
        public void PrintMessage(string message, bool idontKnow)
        {
            _message = message;
        }
    }
    public interface IRepoTransaction
    {
        void InsertTransaction(Transaction transaction);
    }
    public class RepoTransaction : IRepoTransaction
    {
        public void InsertTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
    public interface IMessagePrinter
    {
        void PrintMessage(string message, bool iDontKnow);
    }
    public class BankAccount
    {
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public int Id { get; set; }
    }
    public class Transaction
    {
        public int AccountID { get; set; }
        public string BankAccountNoTo { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
    public enum TransactionType
    {
        Deposit
    }
