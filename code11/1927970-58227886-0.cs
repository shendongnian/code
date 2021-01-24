    public static class ColumnExtensions
    {
        public static void SaveAsCsv(this List<Column> columns, string filePath)
        {
            File.WriteAllText(columns.ToCsv(), filePath);
        }
        public static string ToCsv(this List<Column> columns)
        {
            var csv = new StringBuilder();
            // Write as an expression or simply 
            //csv.AppendCsvHeader(nameof(Item.TimeStamp));
            csv.AppendCsvHeader<string, DateTime>(x => columns.First().ItemList.First().TimeStamp);
            for (var index = 0; index < columns.Count; index++)
            {
                var column = columns[index];
                // Most csv readers don't care if you have a "," at the end of the line. But for completeness we avoid doing that.
                // It makes the code a bit more complicated though. You can ignore this you want.
                csv.AppendCsvHeader(column.ColName, index == columns.Count - 1);
            }
            csv.AppendLine();
            for (var i = 0; i < columns[0].ItemList.Count; i++)
            {
                csv.AppendCsvField(columns[0]
                    .ItemList[i]
                    .TimeStamp.ToString("yyyy/MM/dd HH:mm:ss"));
                for (var index = 0; index < columns.Count; index++)
                {
                    var column = columns[index];
                    csv.AppendCsvField(column.ItemList[i]
                            .Value.ToString("N"), index == columns.Count - 1);
                }
                csv.AppendLine();
            }
            return csv.ToString();
        }
    }
    public static class CsvExtensions
    {
        private const string Delimiter = ",";
        private static string AsCsvFriendly(this string val)
        {
            return val?.Replace(",", ";") ?? string.Empty;
        }
        private static string AddDelimiterIfRequired(bool withoutDelimiter)
        {
            return withoutDelimiter ? string.Empty : Delimiter;
        }
        public static void AppendCsvField(this StringBuilder stringBuilder, string value, bool withoutDelimiter = false)
        {
            stringBuilder.Append($"{value.AsCsvFriendly()}{AddDelimiterIfRequired(withoutDelimiter)}");
        }
        public static void AppendCsvHeader(this StringBuilder stringBuilder, string value, bool withoutDelimiter = false)
        {
            stringBuilder.Append($"{value.AsCsvFriendly()}{AddDelimiterIfRequired(withoutDelimiter)}");
        }
        public static void AppendCsvHeader<TIn, TOut>(this StringBuilder stringBuilder, Expression<Func<TIn, TOut>> f, bool withoutDelimiter = false)
        {
            stringBuilder.Append($"{(f.Body as MemberExpression)?.Member.Name}{AddDelimiterIfRequired(withoutDelimiter)}");
        }
    }
