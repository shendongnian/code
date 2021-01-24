    public class FileMover
    {
        private readonly IFileService _fileService;
        public FileMover(IFileService fileService)
        {
            _fileService = fileService;
        }
        public void MoveFiles(string sourceDir, string destinationDir, string filterText)
        {
            string[] testFiles = _fileService.GetFiles(sourceDir);
            foreach (string file in testFiles) {
                if (file.Contains(filterText)) {
                    _fileService.Move(file, destinationDir);
                }
            }
        }
    }
