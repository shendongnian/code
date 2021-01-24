     public class TableExtensions
        {
            public static Dictionary<string, string> ToDictionary(Table table, int columnOne, int columnTwo)
            {
                int i = 0;
    
                var dictionary = new Dictionary<string, string>();
                foreach (var row in table.Rows)
                {
                    dictionary.Add(row[columnOne], row[columnTwo]);
                }
                return dictionary;
            }
        }
