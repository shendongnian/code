    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Converters;
    using System.Text;
    using System.Runtime.Serialization.Formatters;
    using System.IO;
    using System.Data;
    using System.Xml.Serialization;
    using System.Runtime.Serialization;
    using Newtonsoft.Json.Serialization;
    using System.Web.Services;
    using System.Net;
    
    namespace Batch_report
    {
        public class batch_data 
        {
            public string plant_sl_no { get; set; }
            public string batch_no { get; set; }
            public string batch_no_sl { get; set; }
            public string batch_index { get; set; }
            public string batch_date { get; set; }
            public string recp_id { get; set; }
            public string recp_name { get; set; }
            public string pdt_qty { get; set; }
            public string truck_id { get; set; }
            public string cust_id { get; set; }
            public string load_sent_qty { get; set; }
            public string site { get; set; }
        }
        public class Custom_batch
        {
            [WebMethod]
            [System.Web.Script.Services.ScriptMethod()]
            public static List<batch_data> GetEmployeeName()
            {
                //List<string> abc = new List<string>();
                //string[] arr;
                WebClient client = new WebClient();
                string info = client.DownloadString("http://json.txt");
                string chk = info.Replace("\\", "");
                chk = chk.Substring(1, chk.Length - 2);
    
                List<batch_data> obj = new List<batch_data>();
                obj = JsonConvert.DeserializeObject<List<batch_data>>(chk);
                
                return obj;
            }
        }
    }
