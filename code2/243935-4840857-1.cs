        public static System.Array ResizeArray (System.Array oldArray, int newSize)  
            {
              int oldSize = oldArray.Length;
              System.Type elementType = oldArray.GetType().GetElementType();
              System.Array newArray = System.Array.CreateInstance(elementType,newSize);
         
              int preserveLength = System.Math.Min(oldSize,newSize);
      
              if (preserveLength > 0)
              System.Array.Copy (oldArray,newArray,preserveLength);
             return newArray; 
          }  
       
         public static void Main ()  
               {
                int[] a = {1,2,3};
                a = (int[])ResizeArray(a,5);
                a[3] = 4;
                a[4] = 5;
                for (int i=0; i<a.Length; i++)
                      System.Console.WriteLine (a[i]); 
                }
