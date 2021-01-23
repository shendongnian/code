    class Program
    {
        static void Main(string[] args)
        {
            LookupType lookupType = LookupType.Language;
            Console.WriteLine(GetLookupsByLookupType(lookupType));
            Console.Read();
        }
        public static string GetLookupsByLookupType(LookupType lookupType)
        {
            string SQL = String.Format(@"Select id, name, value, lookuptype from lookups where lookuptype = '{0}'", lookupType.ToString());
            return SQL;                  
        }
    }
    public enum LookupType
    {
        Alignment,
        Language,
        ReEmbedBehavior
    }
