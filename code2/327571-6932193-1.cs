    public class WellFile
    {
       public DateTime FileDate { get; set; }
       public String WellName { get; set; }
       public String OriginalFile {get; set; }
       public WellFile(String FileName)
       {
          var fileHeader = FileName.Split('.').First().Split(' ').ToList();
          WellName = fileHeader.First();
          FileDate = DateTime.Parse(fileHeader.Last());
          OriginalFile = FileName;
       }
    
    }
