        [HttpPost("import", Name = "ImportExcel")]
        public async Task<IActionResult> ImportExcel([FromForm]IFormFile file)
        {
            string folderName = "Upload";
            string newPath = Path.Combine(Guid.NewGuid().ToString() +'_'+ folderName);
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }            
                string sFileExtension = Path.GetExtension(file.FileName).ToLower();
                ISheet sheet;
                string fullPath = Path.Combine(newPath, file.FileName);
                var list = new List<ShipmentImportExcel>();
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
                stream.Position = 0;
                if (sFileExtension == ".xls")
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                }
                else
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                }
                IRow headerRow = sheet.GetRow(0); //Get Header Row
                int cellCount = headerRow.LastCellNum;
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    var obj = new ExcelObject..();
                    IRow row = sheet.GetRow(i);
                    obj.property1 = row.GetCell(0).ToString();
                    obj.property2 = row.GetCell(1).ToString();                   
                    
                    list.Add(obj);
                }
            }
            return Ok(list);
        }
