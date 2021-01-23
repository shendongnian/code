    public interface IDto
    {
        string SomeProperty {get;set;}
    }
    public class DtoLoader
    {
         public static IList<T> CreateLookupList<T>(string currentFileName) where T:IDto, new()
         {
              List<T> items = new List<T>();
              Workbook internalWorkBook = Workbook.Load(currentFileName);
              //Create data table for each worksheet
              foreach (Worksheet curWorksheet in internalWorkBook.Worksheets)
              {
                  T dto = new T();
                  dto.SomeProperty = curWorksheet.Something();
                  items.Add(dto);
              }
              return items;
          }
    }
