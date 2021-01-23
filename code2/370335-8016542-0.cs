    public UserService
    {
        private readonly IUserRepository userRepo;
        private readonly ITransactionStore transactionStore;
    
        //ctor here....
    
        public ExampleUserMethod()
        {
             transactionStore.GetTransactions();
             //do other things
        }
    
        public GetUsers()
        {
            //return users
        }
    
    
    }
    
    public TransactionService
    {
        private readonly ITransactionStore transactionStore;
        private readonly IUserService userService;
    
        //ctor here....
    
        public ExampleTransactionMethod()
        {
             userService.GetUsers();
             //Do other things...
             transactionStore.AddTransaction(transaction);
        }
    }
    public class TransactionStore
    {
        private readonly ITransactionRepository transactionRepo;
    
        public GetTransactions()
        {
            //return transactions
        }
    
        public AddTransaction()
        {
            //return transactions
        }
    }
