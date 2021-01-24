        public class ImagesController : Controller
        {
    
            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }
        
            [HttpPost]
            public async Task<IActionResult> Index(IFormFile file)
            {
                
                if (file == null || file.Length == 0) return Content("file not selected");
                var filename = Path.GetFileName(file.FileName);
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("xx", "xxxx"), true);
                CloudBlobClient client = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = client.GetContainerReference("container_name");
                await blobContainer.CreateIfNotExistsAsync();
                var blockblob = blobContainer.GetBlockBlobReference(filename);
        
                using (var stream = file.OpenReadStream())
                {
                    await blockblob.UploadFromStreamAsync(stream);
                }
        
                return View();
            }
    }
