    try
    {
      Microsoft.Office.Interop.Excel.Application app = 
          System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
    }
    catch
    {
      // Excel is not running.
    }
