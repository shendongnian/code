    using (CachedCsvReader csv = new CachedCsvReader(new StreamReader(filePath), true))
    {
        DataTable Table = new DataTable();
        Table.Load(csv);
    }
