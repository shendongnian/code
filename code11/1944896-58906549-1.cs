    static int MixedSum(int[] v, int[] w)
    {
      int rx = 0;
      for (int c = 0; c < v.Length; c++)
      {
        for (int d = 0; d < w.Length; d++)
        {
          rx = rx + v[c] + w[d];    <------------------------- HERE ADD rx value
          //Console.WriteLine(rx); //Right values gets print out from here.                  
         }
       }
      return rx;  <----------------------- HERE return final sum
    }
    // output
    Console.WriteLine(MixedSum([], []));
