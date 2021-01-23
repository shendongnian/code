    using (var excelPackage = new ExcelPackage())
    {
        adapter.SelectCommand.CommandTimeout = commandTimeout;
        adapter.Fill(table);
        // If you wrap this in a using block which terminates before Save()/SaveAs()
        // it will throw an InvalidOperationException
        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(table.TableName);
        worksheet.Cells["A1"].LoadFromDataTable(table, true);
        //Format the header
        using (ExcelRange range = worksheet.Cells[1, table.Columns.Count]) // all columns
        {
            range.Style.Font.Bold = true;
            ... other stuff
        }
        var newFile = new FileInfo(path);
        excelPackage.SaveAs(newFile);
    }
