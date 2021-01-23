    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Foo
    {
        public static void Main()
        {
            var wellList = new List<String>() {"Smith 08-14 #3-14H11 FINAL 02-05-2011.dwg",
                                               "Scroggins 07-14 3-14 SDWD FINAL 10-28-2009.dwg",
                                               "Smith 08-14 #3-14H11 FINAL 03-11-2011.dwg",
                                               "Russel 10-15 #4-33H21 FINAL 10-07-2009.dwg",
                                                "Scroggins 07-14 3-14 SDWD FINAL 11-29-2010.dwg"}; 
            var ConvertedFileList = wellList.Select(x => new WellFile(x));
            var NewestWellFile = ConvertedFileList.GroupBy(x => x.WellName)
                                          .Select(group => group.OrderByDescending(x =>                              x.FileDate).First().OriginalFile).ToList();
            NewestWellFile.ForEach(x => Console.WriteLine(x));
            Console.Read();
        }
    }
    
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
----------
