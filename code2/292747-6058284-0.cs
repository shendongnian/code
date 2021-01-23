    DataRow dr;
    for(int i = 0; i<ds.Tables.Count; i++){
      for(int j = 0; j<ds.Tables[i].Rows.Count; j++){
        dr = ds.Tables[i].Rows[j];
        //Do something with dr.
      }
    }
