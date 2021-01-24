    while (dgTable3.Columns.Count() != anzNeueVar)
    {
        szahler = zahler.ToString();
    
        DataGridTextColumn textColumn = new DataGridTextColumn();
        textColumn.Header = szahler;
    
        dgTable3.Columns.Add(textColumn);
        zahler++;
    }
