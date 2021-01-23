    public interface IWorksheetHandler
    {
        void LoadFromWorksheet(Worksheet worksheet);
    }
    public class DtoLoader
    {
         public static IList<T> CreateLookupList<T>(string currentFileName) where T:IWorksheetHandler, new()
         {
              List<T> items = new List<T>();
              Workbook internalWorkBook = Workbook.Load(currentFileName);
              foreach (Worksheet worksheet in internalWorkBook.Worksheets)
              {
                  T dto = new T();
                  dto.LoadFromWorksheet(worksheet );
                  items.Add(dto);
              }
              return items;
          }
    }
