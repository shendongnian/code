    interface IFileService
    {
        bool Exists(string fileName);
        void Delete(string fileName);
    }
    class FileService : IFileService
    {
        public bool Exists(string fileName)
        {
            return File.Exists(fileName);
        }
        public void Delete(string fileName)
        {
            File.Delete(fileName);
        }
    }
    class MyRealCode
    {
        private IFileService _fileService;
        public MyRealCode(IFileService fileService)
        {
            _fileService = fileService;
        }
        void DoStuff()
        {
            _fileService.Exists("myfile.txt");
        }
    }
