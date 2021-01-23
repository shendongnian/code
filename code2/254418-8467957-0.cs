    private void TestCreateExcel(IEnumerable<Sales1> data)
        {
            var excelApp = new Excel.Application();
            var workBook = excelApp.Workbooks.Add();
            Excel._Worksheet workSheet = excelApp.ActiveSheet;
            workSheet.Cells[1, "A"] = "Title";
            workSheet.Cells[1, "B"] = "Author(s)";
            workSheet.Cells[1, "C"] = "Release Date";
            workSheet.Cells[1, "D"] = "Total Books Sold";
            workSheet.Cells[1, "E"] = "Last 30 Days Sales";
            workSheet.Cells[1, "F"] = "Average Sales Per Month";
            workSheet.Cells[1, "G"] = "Starting Advance";
            workSheet.Cells[1, "H"] = "Current Advance";
            int index = 1; //Keep track of the which row we're writing to.
            foreach (var n in data)
            {
                index++;
                workSheet.Cells[index, "A"] = n.Title;
                workSheet.Cells[index, "B"] = n.Author;
                workSheet.Cells[index, "C"] = n.ReleaseDate.ToShortDateString();
                workSheet.Cells[index, "D"] = n.TotalBooksSold;
                workSheet.Cells[index, "E"] = n.Last30DaysSales;
                workSheet.Cells[index, "F"] = n.AverageSalesPerMonth;
                workSheet.Cells[index, "G"] = n.StartingAdvance;
                workSheet.Cells[index, "H"] = n.CurrentAdvance;
            }
            workBook.SaveAs(Server.MapPath(filePath + fileName));
            excelApp.Quit();
        }
