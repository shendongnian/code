    try
    {
       Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
       wordApp.Visible = false;
       Microsoft.Office.Interop.Word.Document doc = null;
    
       //Your code here...
       
       doc.Close(false); // Close the Word Document.
       wordApp.Quit(false); // Close Word Application.
    }
    catch (Exception ex)
    {
       MessageBox.Show(ex.Message + "     " + ex.InnerException);
    }
    finally
    {
       // Release all Interop objects.
       if (doc != null)
          System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
       if (wordApp != null)
          System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
       doc = null;
       wordApp = null;
       GC.Collect();
    }
