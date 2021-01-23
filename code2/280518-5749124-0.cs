    public static class UintArrayExtender
       {
          public static string ToWord(this UInt16[] array)
          {
             string val = string.Empty;
             if (array.Length > 0)
             {
                //works the array backwards
                for (int i = array.Length; i >= 0; i--)
                {
                   val += array[i].ToString();
    
                }
             }
             return val;
    
          }
    
       }
