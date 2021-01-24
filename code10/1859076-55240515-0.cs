    for (int i = 0; i < currentline.Length; i++)
    {
          dt.Columns.Add(Convert.ToString(i + 1)); // here is the problem
         //dt.Columns.Add(currentline[i]);                                
     }
