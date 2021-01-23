    int count = 0;
    double sum = 0.0;
    foreach(DataRow row in dTable.Rows){
      if(row[col] != DBNull.Value)
      {
        sum += row[col];  //assuming its type double, or convert it if not
        count++;
      }
    }
    double avg = sum/count;
