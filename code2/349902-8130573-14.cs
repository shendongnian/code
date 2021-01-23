    public void SavePackage(FileInfo fileInfo, DataTable documentList)
    {
        using (ExcelPackage package = new ExcelPackage(fileInfo))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Documents");
            for (Int32 i = 0; i < documentList.Rows.Count; i++)
            {
                for (Int32 j = 0; j < documentList.Columns.Count; j++)
                {
                    worksheet.Cells[i + 1, j + 1].Value = documentList.Rows[i][j];
                }
            }
            package.Save();
        } 
    }
