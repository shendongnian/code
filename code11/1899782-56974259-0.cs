    public enum BlobStorageRepositoryType
    {
    	Core,
    	Quarantine
    }
    
    public interface IBlobStorageRepositoryFactory
    {
    	void Register(BlobStorageRepositoryType type, IBlobStorageRepository blobRepository);
    	IBlobStorageRepository Resolve(BlobStorageRepositoryType type);
    }
    
    public class BlobStorageRepositoryFactory : IBlobStorageRepositoryFactory
    {
    	private readonly Dictionary<BlobStorageRepositoryType, IBlobStorageRepository> _blobRepositories = new Dictionary<BlobStorageRepositoryType, IBlobStorageRepository>();
    
    	public void Register(BlobStorageRepositoryType type, IBlobStorageRepository blobRepository)
    	{
    		_blobRepositories[type] = blobRepository;
    	}
    
    	public IBlobStorageRepository Resolve(BlobStorageRepositoryType type)
    	{
    		return _blobRepositories[type];
    	}
    }
