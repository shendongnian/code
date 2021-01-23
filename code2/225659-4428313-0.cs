     finally
     {
       try
       {
         xl.Visible = false;
         xl.UserControl = false;
         // Close the document and avoid user prompts to save if our
         // method failed.
         wb.Close(SaveChanges,null,null);
         xl.Workbooks.Close();
       }
       catch { }
       // Gracefully exit out and destroy all COM objects to avoid hanging instances
       // of Excel.exe whether our method failed or not.
       xl.Quit();
				
       if (sheet !=null)   { Marshal.ReleaseComObject (sheet); }
       if (wb !=null)      { Marshal.ReleaseComObject (wb); }
       if (xl !=null)      { Marshal.ReleaseComObject (xl); }
			
        sheet=null;
        wb=null;
        xl = null;
        GC.Collect(); 
     }
