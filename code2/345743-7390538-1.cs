    public class ExtractValue
    {
       public ExtractValue(string type)
       {
         PropertyInfo pinfo = typeof(pdfClass).GetProperty("Top" + type);
         var yourList = pinfo.GetValue(yourInstanceOfpdfClass);
         foreach (var listitem in yourList)
         { ... }
       }
    }
