        public static class LinqToExtensions
        {
                [InjectLambda]
                public static string ConvertToString(this DateTime v) => 
                    SqlFunctions.DateName("year", v) + "-" +
                    SqlFunctions.Replicate("0", 2 - SqlFunctions.StringConvert((double)v.Month).TrimStart().Length) +
                    SqlFunctions.StringConvert((double)v.Month).TrimStart() + "-" +
                    SqlFunctions.Replicate("0", 2 - SqlFunctions.DateName("dd", v).Trim().Length) +
                    SqlFunctions.DateName("dd", v).Trim();
                public static Expression<Func<DateTime, string>> ConvertToString() => v =>
                    SqlFunctions.DateName("year", v) + "-" +
                    SqlFunctions.Replicate("0", 2 - SqlFunctions.StringConvert((double)v.Month).TrimStart().Length) +
                    SqlFunctions.StringConvert((double)v.Month).TrimStart() + "-" +
                    SqlFunctions.Replicate("0", 2 - SqlFunctions.DateName("dd", v).Trim().Length) +
                    SqlFunctions.DateName("dd", v).Trim();
        }
