            string FileName = "Records";
            string SheetName = "Records";
            string folderPath = "C:\\New\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, SheetName);
                wb.SaveAs(folderPath + "\\" + FileName + ".xlsx");
            }
        }
