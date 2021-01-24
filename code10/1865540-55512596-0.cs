    /// <summary>
    /// This class uploads files to Azure.
    /// </summary>
    public class SimpleAzureUploader
    {
    private readonly CloudMediaContext _context;
    /// <summary>
    /// Initializes a new instance of the <see cref="SimpleAzureUploader"/> class.
    /// </summary>
    /// <param name="accountName">Name of the Azure Media Services account.</param>
    /// <param name="accountKey">The Account key.</param>
    public SimpleAzureUploader(string accountName, string accountKey)
    {
        _context = new CloudMediaContext(accountName, accountKey);
    }
    /// <summary>
    /// Uplodas a local folder to a non-encrypted asset in Azure.
    /// </summary>
    /// <param name="assetName">Name of the asset.</param>
    /// <param name="path">The directory or file path.</param>
    /// <param name="concurrentTransfers">The max number of concurrent transfers.</param>
    /// <param name="parallelTransferThreads">The max number parallel transfer threads.</param>
    /// <returns></returns>
    public IAsset UploadAsset(string assetName, string path, int concurrentTransfers = 10, int parallelTransferThreads = 10)
    {
        var blobTransferClient = new BlobTransferClient
        {
            NumberOfConcurrentTransfers = concurrentTransfers,
            ParallelTransferThreadCount = parallelTransferThreads
        };
        var asset = _context.Assets.Create(assetName, AssetCreationOptions.None);
        var uploadingAccessPolicy = _context.AccessPolicies.Create("Upload Policy", new TimeSpan(1, 0, 0, 0), AccessPermissions.Write | AccessPermissions.List);
        var uploadingLocator = _context.Locators.CreateLocator(LocatorType.Sas, asset, uploadingAccessPolicy);
        if (Directory.Exists(path) && new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
        {
            UploadFolder(asset, uploadingLocator, path, blobTransferClient);
        }
        else
        {
            UploadFile(asset, uploadingLocator, path, blobTransferClient);
        }
        uploadingLocator.Delete();
        uploadingAccessPolicy.Delete();
        return asset;
    }
    /// <summary>
    /// Uploads the folder to the existing asset.
    /// </summary>
    /// <param name="asset">The existing asset.</param>
    /// <param name="locator">The uploading locator.</param>
    /// <param name="folderPath">The folder path.</param>
    /// <param name="blobTransferClient">The blob transfer client.</param>
    /// <exception cref="System.IO.FileNotFoundException"></exception>
    private void UploadFolder(IAsset asset, ILocator locator, string folderPath, BlobTransferClient blobTransferClient)
    {
        var filePaths = Directory.GetFiles(folderPath);
        if (!filePaths.Any())
        {
            throw new FileNotFoundException(String.Format("No files in directory, check folderPath: {0}", folderPath));
        }
        
        Task.WaitAll((from filePath
                      in filePaths
                      let assetFile = asset.AssetFiles.Create(Path.GetFileName(filePath))
                      select assetFile.UploadAsync(filePath, blobTransferClient, locator, CancellationToken.None)).ToArray());
    }
    /// <summary>
    /// Uploads the file to the existing asset.
    /// </summary>
    /// <param name="asset">The existing asset.</param>
    /// <param name="locator">The uploading locator.</param>
    /// <param name="filePath">The file path.</param>
    /// <param name="blobTransferClient">The blob transfer client.</param>
    private void UploadFile(IAsset asset, ILocator locator, string filePath, BlobTransferClient blobTransferClient)
    {
        var assetFile = asset.AssetFiles.Create(Path.GetFileName(filePath));
        assetFile.UploadAsync(filePath, blobTransferClient, locator, CancellationToken.None).Wait();
    }
    }
