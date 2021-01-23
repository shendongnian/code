	public class ContactServiceFactory
	{    
		IUnitOfWork UnitOfWork { get; private set; }
		
		public ContractServiceFactory(IUnitOfWork unitOfWork)
		{ 
			UnitOfWork = unitOfWork;
		}
	 
		public ContactService Create(Contact obj) 
		{
			return new ContractService(obj, unitOfWork);
		}
	}
