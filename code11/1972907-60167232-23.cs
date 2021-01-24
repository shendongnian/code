    public class AccountRepository
    {
        private readonly EntityContext context;    
    
        public AccountRepository(EntityContext entityContext)
        {
                this.context = entityContext;
        }
        public void Save()
        {
             context.Account.Add(acc); 
             context.SaveChanges();
        }
     }
