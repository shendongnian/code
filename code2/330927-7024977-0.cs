    //[...]
    string tmpName = Path.GetTempFileName();
    File.Delete(tmpName);        
    wb.SaveAs(tmpName, missing, missing, missing, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing);
    wb.Close(false, missing, missing);
    excel.Quit();
    File.Delete(Fname);
    File.Move(tmpName, Fname);
