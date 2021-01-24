    public interface ISatisfyFileType
    {
        bool Satisfies(string fileType);
    }
    
    public class HomeCondition : ISatisfyFileType
    {
        public string FileType => ".txt";
    
        public bool Satisfies(string text)
        {
            return text.Contains("house") || text.Contains("flat");
        }
    }
    
    // the rest of conditions
