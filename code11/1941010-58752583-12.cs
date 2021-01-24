    public interface IFileMover
    {
        void MoveFiles(string sourceDir, string destinationDir, string filterText);
    }
    public class FileMover : IFileMover
    {
        ...
    }
