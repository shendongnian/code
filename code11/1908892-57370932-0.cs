c#
// Install-Package Newtonsoft.Json
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Reflection;
namespace Read_JSON_Dynamically_created_headers
{
    public class VinodJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsClass;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = objectType.GetConstructor(Type.EmptyTypes).Invoke(null);
            PropertyInfo[] props = objectType.GetProperties();
            JObject jo = JObject.Load(reader);
            foreach (JProperty jp in jo.Properties())
            {
                var headValue = jp.Name;
                string tailValue = null;
                if (jp.Name.StartsWith("OrderVINOD_"))
                {
                    headValue = "OrderVINOD";
                    tailValue = jp.Name.Substring(11);
                }
                PropertyInfo headProperty = props.FirstOrDefault(pi =>
                    pi.CanWrite && string.Equals(pi.Name, headValue, StringComparison.OrdinalIgnoreCase));
                if (headProperty != null)
                    headProperty.SetValue(instance, jp.Value.ToObject(headProperty.PropertyType, serializer));
                if (tailValue != null)
                {
                    PropertyInfo trailProperty = props.FirstOrDefault(pi =>
                        pi.CanWrite && string.Equals(pi.Name, "restOfVINOD", StringComparison.OrdinalIgnoreCase));
                    if (trailProperty != null)
                        trailProperty.SetValue(instance, tailValue);
                }
            }
            return instance;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class MyClass
    {
        public string status { get; set; }
        public string msg { get; set; }
        public transaction_details transaction_details { get; set; }
    }
    [JsonConverter(typeof(VinodJsonConverter))]
    public class transaction_details
    {
        public ABC OrderVINOD { get; set; }
        public string restOfVINOD { get; set; }
    }
    public class ABC
    {
        public string bank_ref_num { get; set; }
        public string mihpayid { get; set; }
        public string request_id { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var json = @"{
""status"": 1,
""msg"": ""1 out of 1 Transactions Fetched Successfully"",
""transaction_details"": {
  ""OrderVINOD_20190805224043295"": {
    ""mihpayid"": ""403993715519706476"",
    ""request_id"": """",
    ""bank_ref_num"": ""313124"",
    }
  }
}";
            var obj = JsonConvert.DeserializeObject<MyClass>(json);
        }
    }
}
