    public class ContactService : IContactService
    {
    	private readonly IContactRepository repository;
    	private readonly IUnitOfWork unitOfWork;
    
    	public ContactService(IContactRepository repository, IUnitOfWork unitOfWork)
    	{
    		this.repository = repository;
    		this.unitOfWork = unitOfWork;
    	}
    
    	public void Add(Contact contact)
    	{
    		try
    		{
    			unitOfWork.Start();
    			repository.Add(contact);
    			unitOfWork.Commit();
    		}
    		catch
    		{
    			unitOfWork.Rollback();
    			throw;
    		}
    	}
    }
