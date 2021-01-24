string paths= @"path";
            string name= "Report_.xlsx";
            int i = 1;
            while (File.Exists(System.IO.Path.Combine(paths, name)))
            {   
                name= string.Format("Report_{0}.xlsx",i);
                i++;
            }
            string fullpath = Path.Combine(paths, name);
            book.SaveAs(fullpath, Excel.XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, false, false, Excel.XlSaveAsAccessMode.xlNoChange, Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
            book.Close(0);
            app.Quit();
