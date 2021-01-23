    string max =lsd.Max(tvp=>tvp.Value.FromBase36()).ToBase36();
    public static class Base36 {
    
      public static long FromBase36(this string src) {
      	return src.ToLower().Select(x=>(int)x<58 ? x-48 : x-87).Aggregate(0L,(s,x)=>s*36+x);
      }
    
      public static string ToBase36(this long src) {
        StringBuilder result=new StringBuilder();
        while(src>0) {
          var digit=(int)(src % 36);
          digit=(digit<10) ? digit+48 :digit+87;
          result.Insert(0,(char)digit);
          src=src / 36;
          }
     	return result.ToString();
       }
    }
