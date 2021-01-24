    public class DataFileReader : IDataFileReader
    {
      public delegate DataFileReader Factory(Progress progress);
    
      public Shareholding(Progress progress)
      {
        Progress = progress;
      }
    }
    
    public class ViewModel
    {
      private readonly DataFileReader.Factory factory;
      public ViewModel(DataFileReader.Factory dataFileReaderFactory)
      {
        factory = dataFileReaderFactory;
      }
    
      ...
      IDataFileReader fileImporter = factory(progress);
    }
