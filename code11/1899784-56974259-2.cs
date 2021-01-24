    private readonly IBlobStorageRepository _blobStorageRepository;
    private readonly IBlobStorageRepository _quarantineBlobStorageRepository;
    
    public DocumentService(IBlobStorageRepositoryFactory blobStorageRepositoryFactory)
    {
    	_blobStorageRepository = blobStorageRepositoryFactory.Resolve(BlobStorageRepositoryType.Core);
    	_quarantineBlobStorageRepository = blobStorageRepositoryFactory.Resolve(BlobStorageRepositoryType.Quarantine);
    }
