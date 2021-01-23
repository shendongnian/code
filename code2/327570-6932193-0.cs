    public class WellFile
    {
       DateTime FileDate { get; set; }
       String WellName { get; set; }
       String OriginalFile {get; set; }
       public WellFile(String FileName)
       {
          var fileHeader = FileName.Split(@' ').ToList();
          wellName = fileHeader.First();
          FileDate = DateTime.Parse(fileHeader.Last());
          OriginalFile = FileName;
       }
    
    }
