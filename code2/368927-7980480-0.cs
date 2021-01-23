    enum FileContentType
    {
      PlainText,
      OfficeDoc,
      OffixeXlsx
    }
    
    // Name is ugly so find out better
    public interface IHeuristicZipAnalyzer
    {
       bool IsWorthToZip(int fileSizeInBytes, FileContentType contentType);
       void AddInfo(FileContentType, fileSizeInBytes, int finalZipSize);
    }
