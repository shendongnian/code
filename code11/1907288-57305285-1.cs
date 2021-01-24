    using System.Linq;
    ...
    // backup - same directory as ConfigData.Filename
    //          same filename as ConfigData.Filename with _backup.txt suffix
    string backUpName = Path.Combine(
      Path.GetDirectoryName(ConfigData.Filename),
      Path.GetFileNameWithoutExtension(ConfigData.Filename) + "_backup.txt");
    
    File.Copy(ConfigData.Filename, backUpName, true);
    
    // lines we want to save
    var lines = vocList
      .Select(vocable => $"{vocable.VocGerman.Replace('|', '/')}|{vocable.VocEnglish.Replace('|', '/')}|");
    
    File.WriteAllLines(ConfigData.Filename, lines);
    
    File.Delete(backUpName);
 
