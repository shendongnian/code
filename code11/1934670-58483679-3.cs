    string sqlDel = 
      $@"DELETE 
           FROM products 
          WHERE product_id IN ({string.Join(", ", Enumerable.Range(0, idsToDelete).Select(i => $":prm_Del{i}"))})";
    
    using (OracleCommand cmdDel = new OracleCommand(sqlDel, connexion))
    {
        for (int i = 0; i < idsToDelete.Count; ++i) {
          //TODO: A better choice is explict parameter creation:
          //   cmdDel.Parameters.Add($":prm_Del{i}", idsToDelete[i], OracleType);  
          cmdDel.Parameters.AddWithValue($":prm_Del{i}", idsToDelete[i]);
        }
    
        cmdDel.ExecuteNonQuery();
    }
