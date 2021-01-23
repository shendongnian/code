    IEnumerable<object> CombineArrays ( params object[] arrays )
    {
         foreach (object[] arr in arrays )
         {
              foreach (object obj in arr)
              { 
                   yield return obj;
              }
         }
    } 
