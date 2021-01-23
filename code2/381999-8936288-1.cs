    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    using Castle.ActiveRecord;
    using System.Collections.Generic;
    using System.Data.SqlTypes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Utilities;
    using Newtonsoft.Json.Linq;
    namespace campusMap.Models
    {
        public class JsonAutoComplete
        {
            private int Id;
            [JsonProperty]
            public int id
            {
                get { return Id; }
                set { Id = value; }
            }
            private string Label;
            [JsonProperty]
            public string label
            {
                get { return Label; }
                set { Label = value; }
            }
            private string Value;
            [JsonProperty]
            public string value
            {
                get { return Value; }
                set { Value = value; }
            }
        }
        public class json_autocomplete<t> where t : campusMap.Models.Ijson_autocomplete
        {
            virtual public String get_json_data()
            {
                t[] all_tag = ActiveRecordBase<t>.FindAll();
                List<JsonAutoComplete> tag_list = new List<JsonAutoComplete>();
                foreach (t tag in all_tag)
                {
                    JsonAutoComplete obj = new JsonAutoComplete();
                    obj.id = tag.id;
                    obj.label = tag.name;
                    obj.value = tag.name;
                    tag_list.Add(obj);
                }
                return JsonConvert.SerializeObject(tag_list);
            }
        }
    }
