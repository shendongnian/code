    class Program
    {
        static void Main(string[] args)
        {
            Criteria crit = new Criteria();
            crit.SetVal<Criteria, List<ZipCode> , ZipCode , string>(c => c.ZipCodes, z => z.ZipCodeId, "some value passed in here");
        }
    }
    public class ZipCode
    {
       public string ZipCodeId {get;set;}
       public string Name {get;set;}
    }
    public class Criteria
    {
      public List<ZipCode> ZipCodes {get;set;}
    }
    public static class fordynamic
    {
        public static void SetVal<T, V, K, Z>(this T crit, Expression<Func<T, V>> selector, Expression<Func<K, Z>> key, string value)
        { 
            
        }
    }
