    using (ExcelPackage package = new ExcelPackage(file))
    {
        ExcelWorksheet workSheet = package.Workbook.Worksheets["Table_Methode"];
        int totalRows = workSheet.Dimension.Rows;
    
        List<Methode> methodesList = new List<Methode>();
    
        for (int i = 2; i <= totalRows; i++)
        {
            if (workSheet.Cells[i, 1].Value != null && workSheet.Cells[i, 1].Value != String.Empty)
            {
                methodesList.Add(new Methode
                {
                    NomMethode = workSheet.Cells[i, 1].Value.ToString();
                });
            }
        }
    
        _context.Methode.AddRange(methodesList);
        _context.SaveChanges();
        return methodesList;
    }
