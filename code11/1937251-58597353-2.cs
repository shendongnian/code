    for (int i = 0; i < dt.Rows.Count; i++)
    {
        DataRow dr = dt.Rows[i];
        var item = new DataForExcelExport();
        SetItemData(dr, item, true);
        if (i + ROWS_PER_PAGE < dt.Rows.Count)
        {
            SetItemData(dt.Rows[i + ROWS_PER_PAGE], item, false);
        }
        list.Add(item);
        if ((i + 1) % ROWS_PER_PAGE == 0)
        {
            i += ROWS_PER_PAGE;
            int remaining = dt.Rows.Count - (i + 1);
            if (remaining < 2 * ROWS_PER_PAGE)
            {
                ROWS_PER_PAGE = remaining / 2 + remaining % 2;
            }
        }
    }
