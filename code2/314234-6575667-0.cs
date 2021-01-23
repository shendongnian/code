    private void OutputColumnNamesAsFirstLine(StreamWriter writer)
    {
        StringBuilder md = new StringBuilder();
        PropertyInfo[] columns;
        columns = typeof(DocMetaData).GetProperties(BindingFlags.Public |
                                                      BindingFlags.Instance);
        foreach (var columnName in columns)
        {
            md.Append(columnName.Name); 
            md.Append(DocMetaData.SEPARATOR);
        }
        writer.WriteLine(md.ToString());
    }
