    class FileReader { }
    class UrlFileReader : FileReader { }
    class LocalFileReader : FileReader { }
    class FileReaderFactory
    {
       public FileReader Create(string uri)
       {
          if(IsUrl(uri))
          {
             return new UrlFileReader();
          }
          
          if(IsLocalFile(uri))
          {
             return new LocalFileReader();
          }
          return FileReader();
       }
    }
