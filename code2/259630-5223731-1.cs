    public class ExcelMacroHelper
    {
       public static void Inject(Workbook workbook)
       {
           if ((workbook.Tag as String != "Injected"))
           {
              //Inject the code
              
               workbook.Tag = "Injected";
           }
       }
    }
