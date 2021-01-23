    using System.Collections;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Microsoft.SqlServer.Server;
    
    public partial class UserDefinedFunctions
    {
        private static readonly Regex ProfileRegex = new Regex(@"([a-zA-Z]+):[A-Z]:(\d+):(\d+)");
    
        [SqlFunction(FillRowMethodName = "FillProfileRow",TableDefinition="Property nvarchar(250), Value nvarchar(2000)")]
        public static IEnumerable ParseProfileString(SqlString names, SqlString values)
        {
            var dict = ProfileRegex
                .Matches(names.Value)
                .Cast<Match>()
                .ToDictionary(
                    x => x.Groups[1].Value,
                    x => values.Value.Substring(int.Parse(x.Groups[2].Value), int.Parse(x.Groups[3].Value)));
    
            return dict;
        }
    
        public static void FillProfileRow(object obj, out string Property, out string Value)
        {
            var x = (KeyValuePair<string, string>) obj;
            Property = x.Key;
            Value = x.Value;
        }
    };
