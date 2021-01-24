    using System;
    using System.Data;
    using Microsoft.SqlServer.Dts.Pipeline.Wrapper;
    using Microsoft.SqlServer.Dts.Runtime.Wrapper;
    using System.Web.Script.Serialization;
    using System.Collections.Generic;
    #endregion
    
    [Microsoft.SqlServer.Dts.Pipeline.SSISScriptComponentEntryPointAttribute]
    public class ScriptMain : UserComponent
    {
        public override void CreateNewOutputRows()
        {
            string json = @"{""data"":[{""created_at"":""2016-03-12 09:45:00"",""created_at_unix"":1457772300,""shop_name"":""DK - Some name"",""location_id"":1111,""custom_location_id"":""2222"",""custom_shop_id"":""2222"",""shop_id"":3333,""count_in"":""1"",""count_out"":""1"",""timekey"":3},{""created_at"":""2016-03-12 09:45:00"",""created_at_unix"":1457772300,""shop_name"":""test2"",""location_id"":1111,""custom_location_id"":""2222"",""custom_shop_id"":""2222"",""shop_id"":3333,""count_in"":""1"",""count_out"":""1"",""timekey"":3}]}";
    
            RootObject Test = new JavaScriptSerializer().Deserialize<RootObject>(json);
    
            /*
             * This is where data gets added to the output buffer.
             * After AddRow() you are basically mapping the column you manually added(on the left) to the data(on the right).
             * using a foreach loop to loop through the deserialize json
             */
            foreach (var item in Test.data)
            {
                Output0Buffer.AddRow();
                Output0Buffer.createdat = item.created_at;
                Output0Buffer.shopname = item.shop_name;
            }
        }
        public class RootObject
        {
            public List<data> data { get; set; }
        }
    
        public class data
        {
    
            public string created_at { get; set; }
            public int created_at_unix { get; set; }
            public string shop_name { get; set; }
            public int location_id { get; set; }
            public string custom_location_id { get; set; }
            public string custom_shop_id { get; set; }
            public int shop_id { get; set; }
            public string count_in { get; set; }
            public string count_out { get; set; }
            public int timekey { get; set; }
        }
    
    }
