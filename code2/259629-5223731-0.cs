    public class ExcelMacroHelper
    {
       public static void Inject(Workbook workbook)
       {
           if ((worksheet.Tag as String != "Injected"))
           {
              //Inject the code
              
               worksheet.Tag = "Injected";
           }
       }
    }
