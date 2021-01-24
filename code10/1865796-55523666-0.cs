    public class SomeClass
    {
        private MyConfig _options;
        public SomeClass(IOptions<MyConfig> options)
        {
            _options = options.Value;
        }
        private async Task<string> SaveAnnouncement(IFormFile file = null, string base64 = null)
        {
            string path = _options.FolderAnnouncement;
            ...
        }
    }
