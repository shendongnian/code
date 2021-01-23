    public void BuildResultFile(List<ResultSet> resultSets, Stream stream)
    {
        using (var package = new ExcelPackage(stream))
        {
            // Create Excel file from resultSets
            package.Save();
        }
    }
