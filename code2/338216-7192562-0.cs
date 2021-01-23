    int e1;
    foreach (var item in QueryResult)
    {
        if (Int32.TryParse(item.E1, out e1))
        {
            tempDT.Rows.Add(new object[] { e1, item.D1 });
        }
    }
