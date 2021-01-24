    namespace MyNamespace
    {
        using System.IO;
    
        public interface IFileSystemHelper
        {
            void SaveFileData(string fileLocation, string fileName);
        }
    
        public class FileSystemHelper : IFileSystemHelper
        {
            public void SaveFileData(string fileLocation, string fileName)
            {
                using (FileStream outputFile = new FileStream(Path.Combine(fileLocation, fileName), FileMode.OpenOrCreate))
                {
                    // TODO: Save file
                }
            }
        }
    }
