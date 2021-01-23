    public static class extension
    {
     public static string To_String<T>(this IEnumerable<T> data) where T:IConvertable
     {
      if(typeof(T).Equals(typeof(char)))
       return data.Select(obj => obj.ToChar(null).ToString()).Aggregate((cur, nex) => cur + "," + nex);;
      else
       return data.Select(obj => obj.ToString()).Aggregate((cur, nex) => cur + "," + nex);
     }
    }
