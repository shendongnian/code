    for (int i = 0; i < dt1.Rows.Count; i++)
    {
       var outerRow = dt1.Rows[i];
       for (int j = 0; i + 1 < dt1.Rows.Count; j++)
       {
         var innerRow = dt1.Rows[j];
         if (Equals(outerRow["NUM"] == innerRow["NUM"]))
         {
            if (outerRow["Name"].ToString().LevenshteinDistance(innerRow.ToString()) <= 10)
            {
               Logging.Write(...);
            }
         }
      }
