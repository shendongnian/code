    public class Product 
    {
    }
    public interface IProductRepository
    {
        void Save(Product p);
    }
    public class ProductRepository : IProductRepository
    {
        public void Save(Product p)
        {
            Console.WriteLine("Saved Product");
        }
    }
    public class File 
    {
    }
    public interface IFileRepository
    {
        void Save(File f);
    }
    public class FileRepository : IFileRepository
    {
        public void Save(File f)
        {
            Console.WriteLine("Saved File");
        }
    }
    public class Repository 
    {
    }
    
