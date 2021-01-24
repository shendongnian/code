    public interface IFileSystemEntity
    {
          string Path { get; set; }
    }
    public class MyFiles: IFileSystemEntity
    {
        public int MyFilesId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        protected OnDelete() { // here is logic for removing the file from OS }
    }
