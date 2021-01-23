    namespace Data.Entities
    {
       [FlatFileContainerRecord(RecordLength = 157)]
        public class FlatFile<FlatFileHeader, DT, FlatFileFooter> 
        {
           public FlatFileHeader Header { get; set; }
           public List<DT> Details { get; set; }
           public FlatFileFooter Control { get; set; }
           public FlatFile()
        {
            Details = new List<DT>();
        }
    }
  
