     // try this
     public static MemoryStream GetFile()
        {
            MemoryStream stream = new MemoryStream();
            // do your thing
            XSSFWorkbook wb = new XSSFWorkbook();
            ISheet sheet = wb.CreateSheet("Test");
            var row = sheet.CreateRow(0);
            var cell = row.CreateCell(0);
            cell.SetCellValue("Test");
            wb.Write(stream);    
            // reset position here
            stream.Position = 0;
            return stream;
        }
