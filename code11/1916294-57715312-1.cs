    List<int> WriteRowValues(IList<dynamic> items)
    {
        var activeIndexes = new List<int>();
        foreach(var item in items)
        {
            worksheet.Cells[rowIndex, 0].Value = item.Name;
            worksheet.Cells[rowIndex, 1].Value = item.Amount;
            worksheet.Cells[rowIndex, 2].Value = item.Active;
            if (item.Active)
            {
                activeIndexes.Add(rowIndex);
            }
            rowIndex++;
        }
        return activeIndexes;
    }
