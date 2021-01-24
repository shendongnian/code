    List<string> list = new List<string>();
            object missing = Type.Missing;
            Excel.Application oXL = new Excel.Application();
            oXL.Visible = false;
            Excel.Workbook oWB = oXL.Workbooks.Add(missing);
            string fileName = string.Empty;
            Excel.Worksheet oSheet = oWB.ActiveSheet as Excel.Worksheet;
            var oSheetItems = oSheet;
            if (oSheetItems != null)
            {
                oSheetItems.Name = "sheatName";
                int i = 1;
                foreach (var item in list)
                {
                    //insert your object
                    oSheetItems.Cells[i, 1] = item;
                    oSheetItems.Cells[i, 2] = item;
                    i++;
                }
            }
            fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                       + "\\ExcelName.xlsx";
            oWB.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook,
                missing, missing, missing, missing,
                Excel.XlSaveAsAccessMode.xlNoChange,
                missing, missing, missing, missing, missing);
            oWB.Close(missing, missing, missing);
            oXL.UserControl = true;
            oXL.Quit();
