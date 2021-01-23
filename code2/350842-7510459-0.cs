    System.Text.StringBuilder sb = new System.Text.StringBuilder();
     while (SQLRD.Read())
      {
      sb.Append(String.Format("{0},{1},{2},{3},{4},{5},{6},{7}\n",
          SQLRD[0],SQLRD[1],SQLRD[2],SQLRD[3],SQLRD[4],SQLRD[5],SQLRD[6],SQLRD[7]));
       }
