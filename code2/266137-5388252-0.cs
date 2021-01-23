    public class FileWriterRegistry
    {
       public void Register(CustomWriter writer)
       {
       }
       public void WriteAllFiles()
       {
           ... call WriteFile() for each registered writer
       }
    }
