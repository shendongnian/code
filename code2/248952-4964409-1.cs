    string txt = OrigText.Substring(0, OrigText.IndexOf(",", 0)).ToUpper()
    for (int vcl = 0; vcl < resultTable.Rows.Count; vcl++)
    {
      if (resultTable.Rows[vcl][0].ToString() == txt && resultTable.Rows[vcl][1].ToString().Length > 0)
      {
          foundSpot = vcl;
          break;
      }
    }
