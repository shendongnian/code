    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    namespace Analiz
    {
            public class anlz
            {       
                public static void metot()
                {
        			System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<Test>));
        			List<MyDetail> myDetails = (List<Test>)serializer.ReadObject(new FileStream(@"C:\Users\Durak\AppData\Roaming\MetaQuotes\Terminal\D0E8209F77C8CF37AD8BF550E51FF075\MQL5\Files\json\deneme.json", FileMode.Open, FileAccess.Read));            
                }
            }
            public class MyDetail
            {
                public string emirtipi{get;set;}
                public string miktar{get;set;}
                public string takip{ get; set;}
            }
    }
