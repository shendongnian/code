    for (int i = 0; i < TickerPrice.Rows.Count; i++)
    {
        DataRow destRow = Recap.NewRow();
        destRow["Move Ticker price"] = TickerPrice.Rows[i]["CHG_PCT_1D"];
        destRow["Move Index price"] = IndexPrice.Rows[i]["CHG_PCT_1D"];
        Recap.Rows.Add(destRow);
    }
