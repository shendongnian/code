Dictionary<string, string> listProdOnDb = new Dictionary<string, string>();
    `Dictionary<string, string> listProdJson = new Dictionary<string, string>();
    foreach (var item in ListaProdJson)
            {
                listProdJson.Add(item.codProdotto.Trim(), item.descrizione.Trim());
            }
    strSql = "SELECT Cod_Prod_Rpt,Des_Prod_Rpt FROM xxxx Where xxxxx = xxx";
      using (SqlCommand command = new SqlCommand(strSql, connection))
                {
                using (SqlDataReader sdr = command.ExecuteReader())
                    {
                    string[] col = { "", "" };
                    while (sdr.Read())
                        {
                        if (!sdr.IsDBNull(0))
                            col[0] = sdr.GetString(0).Trim();
                        if (!sdr.IsDBNull(1))
                            col[1] = sdr.GetString(1).Trim();
                        // add items
                        if (col[0] != "") // check if key is valid
                            listProdOnDb.Add(col[0], col[1]);
                    }
                        
                    }
                }
     IEnumerable<string> onlyInFirstSet = listProdJson.Keys.Except(listProdOnDb.Keys);
     if(onlyInFirstSet.Count() > 0) {
    .....
     }
`
    
