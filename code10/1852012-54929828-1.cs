        public void SaveExcelFile(Excel.Application app, string exportPath)
        {
            try
            {
                //Stops from asking to overwrite
                app.DisplayAlerts = false;
                Excel._Worksheet sheet = app.ActiveSheet;
                //Save and close
                sheet.SaveAs(exportPath);
                app.Quit();
            }
            catch (Exception ex)
            {
                //If something fails, show the error
                Console.WriteLine("ERROR: Failed to save Excel file! " + ex);
            }
        }
