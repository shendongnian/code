    int MerchNo = 0;
    foreach (DataRow r in dtExcel.Rows)
    {
       if (!String.IsNullOrEmpty(r["MerchantNo"].ToString().Trim()) &&
           Int32.TryParse(r["MerchantNo"].ToString().Trim(), out MerchNo))
       {
          string strSql = String.Format("INSERT INTO SomeTable(MerchantNo, TerminalNum, CardType, Date) VALUES('{0}', '{1}', '{2}', '{3}');", r["MerchantNo"], r["TerminalNum"], r["CardType"], r["Date"]);
          
          SqlCommand scInsertCommand = new SqlCommand(strSql);
          //do transacion and connection assignment, and error handling
          scInsertCommand.ExecuteNonQuery();
       }
    }
