    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication120
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, decimal> dict1 = new Dictionary<string, decimal>() { { "aa", 1 }, { "bb", 2 } };
                Dictionary<string, decimal> dict2 = new Dictionary<string, decimal>() { { "bb", 2 } };
                Dictionary<string, decimal> dict3 = new Dictionary<string, decimal>() { { "aa", 0 } };
                Dictionary<string, decimal> dict4 = new Dictionary<string, decimal>() { { "aa", 5 }, { "bb", 7 } };
                List<string> keys = dict1.Keys.ToList();
                keys.AddRange(dict2.Keys);
                keys.AddRange(dict3.Keys);
                keys.AddRange(dict4.Keys);
                keys = keys.Distinct().OrderBy(x => x).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Dict 1", typeof(decimal));
                dt.Columns.Add("Dict 2", typeof(decimal));
                dt.Columns.Add("Dict 3", typeof(decimal));
                dt.Columns.Add("Dict 4", typeof(decimal));
                decimal value1 = 0;
                decimal value2 = 0;
                decimal value3 = 0;
                decimal value4 = 0;
                foreach (string key in keys)
                {
                    Boolean foundValue1 = dict1.TryGetValue(key, out value1);
                    Boolean foundValue2 = dict2.TryGetValue(key, out value2);
                    Boolean foundValue3 = dict3.TryGetValue(key, out value3);
                    Boolean foundValue4 = dict4.TryGetValue(key, out value4);
                    dt.Rows.Add(new object[] {
                        key,
                        foundValue1 ? (decimal?)value1 : null,
                        foundValue2 ? (decimal?)value2 : null,
                        foundValue3 ? (decimal?)value3 : null,
                        foundValue4 ? (decimal?)value4 : null
                    });
                }
            }
        }
    }
