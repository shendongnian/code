    insertRaffleEntries.Parameters.Add("PromoCode", MySqlDbType.VarChar);
    // Define the other parameters with the proper DBType here 
    .....
      
    for (int i = 0; i <= dtRaffleEntries.Rows.Count - 1; i++)
    {
       for (int c = 0; c <= Convert.ToInt32(dtRaffleEntries.Rows[i]["RaffleEntries"].ToString()) - 1; c++)
       {
            errorline = dtRaffleEntries.Rows[i]["ORNumber"].ToString(); //FLR
            insertRaffleEntries["PromoCode"].Value =  RafflePromoCode;
            // Set the value for the other parameter here 
            .....
            insertRaffleEntries.ExecuteNonQuery();
       }
    }
      
