    public static File Create(string fileName)
    {
        var factory = GetFactory(fileName);
        return factory.CreateFile(fileName);
    }
    
    public static IFileFactory GetFactory(string fileName)
    {
        if(Path.GetExtension(fileName).toUpperInvariant() == ".JPG")
        {
            return new ImageFileFactory();
        }
        //...
    }
    
    public interface IFileFactory
    {
        File CreateFile(string fileName);
    }
    public class ImageFileFactory : IFileFactory
    {
        public File CreateFile(string fileName)
        {
            int width = GetWidth(fileName);
            int height = GetHeight(fileName);
            return new ImageFile(fileName, width, height);
        }
    }
