     foreach (var column in fullRange.Columns)
     {
       // vals will be a one-dimensional array 
       // of all values in that column!
       var vals = column.Value;
       foreach (var val in vals)
       {
           if (val == null) continue;
           string cellValue = val.ToString();
           //Debug.WriteLine(" Value read: " + cellValue);
           //do something with the value...
                              
       }
     }
