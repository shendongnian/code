    using DevExpress.Xpo.DB;
    using System.Data;
    using System.Linq;
    
    namespace DevExpress.Xpo
    {
        public static class StatementsExtensions
        {
            public static string ToSql(this SelectStatement[] selects) => string.Join("\r\n", selects.Select(s => s.ToString()));
            public static string ToSql(this ModificationStatement[] dmls) => string.Join("\r\n", dmls.Select(s => s.ToString()));
        }
    }
