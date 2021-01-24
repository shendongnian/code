    while (dgTable3.Columns.Count() != anzNeueVar)
    {
        szahler = zahler.ToString();
        // Move the declaration here
        DataGridTextColumn textColumn = new DataGridTextColumn {Header = szahler};
        dgTable3.Columns.Add(textColumn);
        zahler++;
    }
