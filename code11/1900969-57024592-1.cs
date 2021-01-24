    public class DownloadHelper 
    {
        private CoreTestContextFactory _factory;
        public DownloadHelper(CoreTestContextFactory dbContextFactory)
        {
            _factory = dbContextFactory;
        } 
    
        public async Task DownloadFile(Test item, string url) {
            // Download the file from url
            // Add details of downloaded file to the test object
    
            using(var context = _factory.CreateContext())
            {
                item.Files.Add(new TestFile {Name = "NewFile", Path = "FilePath"});
                _context.SaveChanges();
            }
        }
    }
