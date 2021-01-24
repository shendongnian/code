        public interface IFileWrapper
        {
            FileInfo[] GetFiles(DirectoryInfo di);
        }
    
        public class FileWrapper : IFileWrapper
        {
            public FileInfo[] GetFiles(DirectoryInfo di)
            {
                return di.GetFiles();
            }
        }
