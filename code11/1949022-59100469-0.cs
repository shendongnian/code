       public class Suffixes
        {
            public const string Collate = "--Collate";
        }
    
        public class CollationDbCommandInterceptor : DbCommandInterceptor
        {
            private const string CollateSyntax = " collate turkish_ci_as";
    
            public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
            {
                var args = command.Parameters.Cast<DbParameter>()
                               .Where(t => t.DbType == DbType.String && t.Value.ToString().EndsWith(Suffixes.Collate)).ToList();
                if (args.Count <= 0)
                    return base.ReaderExecuting(command, eventData, result);
    
                foreach (var parameter in args)
                {
                    parameter.Value = parameter.Value.ToString().Replace(Suffixes.Collate, "");
                    var equality = $"= {parameter.ParameterName}";
                    
                    var ixs = AllIndexesOf(command.CommandText, equality);
                        
    #pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                    foreach (var eq in ixs)
                    {
                        command.CommandText = command.CommandText.Insert(eq+equality.Length,CollateSyntax);
    
                    }
    #pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
    
                }
    
    
    
                return base.ReaderExecuting(command, eventData, result);
            }
    
            private static IEnumerable<int> AllIndexesOf(string str, string value)
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("the string to find may not be empty", nameof(value));
                var indexes = new List<int>();
                for (var index = 0; ; index += value.Length)
                {
                    index = str.IndexOf(value, index);
                    if (index == -1)
                        return indexes;
                    indexes.Insert(0,index);
                }
            }
        }
