            List<Item> list = new List<Item>()
            { 
                new Item() { City = "Houston", Temperature = "80", Season = "Fall"},
                new Item() { City = "Chicago", Temperature = "64", Season = "Fall"},
                new Item() { City = "San Francisco", Temperature = "70", Season = "Fall"},
                new Item() { City = "Houston", Temperature = "101", Season = "Summer"},
                new Item() { City = "Chicago", Temperature = "84", Season = "Summer"},
                new Item() { City = "San Francisco", Temperature = "90", Season = "Summer"}
            };
            var listGroups = from item in list 
                             group item by item.City;
            int count = 2;
            var fileInfo = new FileInfo(@"myworkbook.xlsx");
            using (var excelPackage = new ExcelPackage(fileInfo))
            {
                var workbook = excelPackage.Workbook.Worksheets.Add($"Worksheets_{DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss")}");
                workbook.Cells[2, 1].Value = "Summer";
                workbook.Cells[3, 1].Value = "Fall";
                foreach (var item in listGroups)
                {
                    workbook.Cells[1, count].Value = item.Key;
                    foreach (var temp in item)
                    {
                        if (temp.Season == "Summer")
                            workbook.Cells[2, count].Value = temp.Temperature;
                        else
                            workbook.Cells[3, count].Value = temp.Temperature;
                    }
                    count++;
                }
                excelPackage.Save();
            }
