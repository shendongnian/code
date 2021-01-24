        [HttpGet]
        public IActionResult GetInventoryExcel()
        {
            List<ExpandoObject> results = MagicallyGenerateList();
            return ToExcelResponse("example", results.ToArray());
        }
        public IActionResult ToExcelResponse(string filename, dynamic[] results)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (var package = new ExcelPackage(memoryStream))
            {
                var worksheet = package.Workbook.Worksheets.Add(filename);
                int x = 1, y = 0;
                foreach (var result in results)
                {
                    x = 1;
                    y++;
                    foreach (var key in ((IDictionary<string, object>)result).Keys)
                    {
                        if (((IDictionary<string, object>)result).TryGetValue(key, out var value))
                        {
                            worksheet.Cells[x++, y].Value = value;
                        }
                        else
                        {
                            x++;
                        }
                    }
                }
                package.Save();
                memoryStream.Position = 0;
                return File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", filename + ".xlsx");
            }
        }
