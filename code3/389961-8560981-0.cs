    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Script.Serialization;
    
    class Sample {
        static void Main(){
            string json = File.ReadAllText("json.txt");
            var jss = new JavaScriptSerializer();
            var dic = jss.Deserialize<Dictionary<string, object>>(json);
            var noa = (ArrayList)dic["noa"];
            var noa_1 = (Dictionary<string, object>)noa[0];
            Console.WriteLine("title is {0}",noa_1["title"]);
            Console.WriteLine("artist is {0}",noa_1["artist"]);
        }
    }
