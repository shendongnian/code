    public enum RepoTypes { Blob, Quarantine }
    
    ...
    
    public interface IRepoResolver
    {
    	//resolve using method
        IBlobStorageRepository GetRepo(RepoTypes rt);
    	
    	//resolve usnig indexer
    	IBlobStorageRepository this[RepoTypes rt]
        {
            get;
        }
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
    	
    	public IBlobStorageRepository this[RepoTypes rt] { get => _repos[rt]; }
    }
    
    ...
    
    services.AddSingleton<IRepoResolver, RepoResolver>();
    
    ...
    public class Some
    {
    	public Some(IRepoResolver rr)
    	{
            var blob1 = rr.GetRepo(RepoTypes.Blob);
    		var blob2 = rr[RepoTypes.Blob];
    	}
    }
