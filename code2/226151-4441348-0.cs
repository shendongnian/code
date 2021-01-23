    public interface IFileProcessor
    {
        void Process(string fileName);
        IEnumerable<string> FileExtensions {get;}
    }
    
