    public DataTable readCSV(string filePath)
    {
        var dt = new DataTable();
        var csv = new CsvReader(new StreamReader(filePath));
        // Creating the columns
        typeof(Product).GetProperties().Select(p => p.Name).ToList().ForEach(x => dt.Columns.Add(x));
        // Adding the rows
        csv.GetRecords<Product>().ToList().ForEach(line => dt.Rows.Add(line.ID, line.SOMETHING));
        return dt;
    } // End readCSV : DataTable
