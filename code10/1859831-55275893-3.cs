    int columnCount = dt_1sttxtfile.Count;
    for (int column = 0; column < columnCount; column++)
    {
           if (reference_File.TryGetValue(dt_1sttxtfile[column], out var referenceValue))
             {
               if (string.Compare(referenceValue, dt_2ndtxtfile[column], StringComparison.InvariantCulture) == 0)
                   {
                       // perform your task
                   }
              }
      }
