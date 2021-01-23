      static void Main()
      {
         float[] array1 = new float[] { 1, 1, 1, 1 };
         float[] array2 = new float[] { 2, 2, 2, 2 };
         float[] array3 = new float[] { 3, 3, 3, 3 };
         float[] array4 = new float[] { 4, 4, 4, 4 };  
         float[] avg = CrossAverage (array1, array2, array3, array4);
         Console.WriteLine (string.Join ("|", avg.Select(f => f.ToString ()).ToArray()));
      }
      private static float[] CrossAverage (params float [][] arrays)
      {
         int [] count = new int [arrays[0].Length];
         float [] sum = new float [arrays[0].Length];
         for (int j = 0; j < arrays.Length; j++)
         {
            for (int i = 0; i < count.Length; i++)
            {
               count[i] ++;
               sum[i] += arrays[j][i];
            }
         }
         float [] avg = new float [arrays[0].Length];
         for (int i = 0; i < count.Length; i++)
         {
            avg[i] = sum[i] / count[i];
         }
         return avg;
      }
