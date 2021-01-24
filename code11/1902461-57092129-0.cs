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
                Dictionary<string, string> dict1 = new Dictionary<string, string>() { { "aa", "1" }, { "bb", "2" } };
                Dictionary<string, string> dict2 = new Dictionary<string, string>() { { "bb", "2" } };
                Dictionary<string, string> dict3 = new Dictionary<string, string>() { { "aa", "0" } };
                Dictionary<string, string> dict4 = new Dictionary<string, string>() { { "aa", "5" }, { "bb", "7" } };
                List<string> keys = dict1.Keys.ToList();
                keys.AddRange(dict2.Keys);
                keys.AddRange(dict3.Keys);
                keys.AddRange(dict4.Keys);
                keys = keys.Distinct().OrderBy(x => x).ToList();
                DataTable dt = new DataTable();
                dt.Columns.Add("Dict 1", typeof(string));
                dt.Columns.Add("Dict 2", typeof(string));
                dt.Columns.Add("Dict 3", typeof(string));
                dt.Columns.Add("Dict 4", typeof(string));
                string value1 = "";
                string value2 = "";
                string value3 = "";
                string value4 = "";
                foreach (string key in keys)
                {
                    Boolean foundValue1 = dict1.TryGetValue(key, out value1);
                    Boolean foundValue2 = dict2.TryGetValue(key, out value2);
                    Boolean foundValue3 = dict3.TryGetValue(key, out value3);
                    Boolean foundValue4 = dict4.TryGetValue(key, out value4);
                    dt.Rows.Add(new string[] {
                        foundValue1 ? value1 : null,
                        foundValue2 ? value2 : null,
                        foundValue3 ? value3 : null,
                        foundValue4 ? value4 : null
                    });
                }
            }
        }
    }
