    public class FileWriterRegistry
    {
       public void Register(CustomerWriter writer)
       {
       }
       public void WriteAllFiles()
       {
           ... call Write() for each registered writer
       }
    }
