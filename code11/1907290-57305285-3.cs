    using System.Linq;
    ...
    // backup - same directory as ConfigData.Filename
    //          same filename as ConfigData.Filename with _backup.txt suffix
    string backUpName = Path.Combine(
      Path.GetDirectoryName(ConfigData.Filename),
      Path.GetFileNameWithoutExtension(ConfigData.Filename) + "_backup.txt");
    
    File.Copy(ConfigData.Filename, backUpName, true);
    
    // lines we want to save (see comments below)
    var lines = vocList
      .Select(vocable => string.Join("|", // do not hardcode, but Join into line
         vocable.VocGerman.Replace('|','/'),
         vocable.VocEnglish.Replace('|', '/'),
         vocable.CreationDate.ToString("dd.MM.yyyy"),
         vocable.AssignedDate.ToString("dd.MM.yyyy"),
         vocable.SuccessQueue,
         vocable.TimeQueue,
         ""
       ));
    
    File.WriteAllLines(ConfigData.Filename, lines);
    
    File.Delete(backUpName);
