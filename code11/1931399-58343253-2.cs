    static public class ConverterHelper
    {
      static public T ConvertTo<T>(this object obj, bool returnDefaultOnError = false)
      where T : IConvertible
      {
        try
        {
          return (T)Convert.ChangeType(obj, typeof(T));
        }
        catch
        {
          if ( returnDefaultOnError )
            return default(T);
          else
            throw;
        }
      }
    }
