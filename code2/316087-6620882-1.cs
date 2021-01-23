    public class AccountRepository : IAccountRepository
    {
       private readonly IUnitofWork unitofWork;
       
       public AccountRepository(IUnitofWork unitofWork)
       {
          this.unitofWork = unitofWork;
       }
       //Implement interface method
       public Account Get(int id)
       {
          //some logic or just the call to the unit of work
          return unitofWork.Get(id);
       }
    }
