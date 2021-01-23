    XmlNodeList nodes = doc.SelectNodes("//org.yccheok.jstock.engine.Stock");
    // Dynamically build your data table
    DataTable table = new DataTable();
    foreach (XmlElement field in nodes[0].SelectNodes(".//*[not(./*)]"))
        table.Columns.Add(new DataColumn(field.Name));
    // Populate with data
    foreach (XmlElement element in nodes)
    {
        DataRow row = table.NewRow();
        foreach (DataColumn column in table.Columns)
            row[column.ColumnName] = element.SelectSingleNode("//" + 
                column.ColumnName).InnerText;
        table.Rows.Add(row);
    }
    // Show sorted results
    table.DefaultView.Sort = "code asc";
    foreach (DataRowView row in table.DefaultView)
    {
        foreach (DataColumn column in table.Columns)
            Console.WriteLine("{0}: {1}", column.ColumnName, row[column.ColumnName]);
        Console.WriteLine();
    }
    Console.ReadKey();
