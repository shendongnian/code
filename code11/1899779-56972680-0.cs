    public enum RepoTypes { Blob, Quarantine }
    
    ...
    
    public interface IRepoResolver
    {
    	IBlobStorageRepository GetRepo(RepoTypes rt);
    }
    
    ...
    
    public sealed RepoResolver : IRepoResolver
    {
    	private readonly Dictionary<RepoTypes, IBlobStorageRepository> _repos;
    
    	public RepoResolver()
    	{
    		_repos[RepoTypes.Blob] = new BlobStorageRepository(...);
    		_repos[RepoTypes.Quarantine] = new BlobStorageRepository(...);
    	}
    
    	public IBlobStorageRepository GetRepo(RepoTypes rt) => _repos[rt];
    }
    
    ...
    
    services.AddSingleton<IRepoResolver, RepoResolver>();
