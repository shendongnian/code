    public class FileBase
    {
       protected FileInfo _source;
    
       protected virtual string GetMonth()
       {
           // 2/3 Files have the Month in this location
           // So I want this to be used unless a derived class
           // redefines this method.
           return _source.Name.Substring(Source.Name.Length - 15, 2);
       }
    
       public void MoveFileToProcessedFolder()
       {
          MoveFileToFolder(Properties.Settings.Default.processedFolder + GetMonth());
       }
    
       private void MoveFileToFolder(string destination)
       {
           ....
       }
    }
    
    public class FooFile : FileBase
    {
        protected override string GetMonth()
        {
            return _source.Name.Substring(Source.Name.Length - 9, 2);
        }
    }
    
    public class Program
    {
        FooFile x = new FooFile("c:\Some\File\Location_20110308.txt");
        x.MoveFileToProcessedFolder();
    }
