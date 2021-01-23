    for(int i = resultsDT.Rows.Count - 1; i >= 0; i--)
    {
        if ((string)resultsDT.Rows[i]["LYSMKWh"] == "0")
        {
            int intKWh = Convert.ToInt32(resultsDT.Rows[i]["KWH"]);
            if (intKWh < 5000)
            {
                resultsDT.Rows[i].Delete();                        
            }
        }
        resultsDT.AcceptChanges();
    }
