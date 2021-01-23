    public class ContentType
    {
        public virtual string GetNewFilename(string originalFilename, int fileIndex)
        {
            // get file name here
        }
    }
    
    public class SpecialContentType : ContentType
    {
        // Inherrits all the properties of ContentType
    
        public override string GetNewFilename(string originalFilename, int fileIndex)
        {
            // get special file name here
        }
    }
