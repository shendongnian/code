    class Program
    {
        static void Main(string[] args)
        {
            var json = @"[{""Name"":""John"",""Age"":""22"",""Json"":[{""Prop"":1}]},"
                      + @"{""Name"":""Eric"",""Age"":""25"",""Json"":[{""Prop"":2}]},"
                      + @"{""Name"":""Joan"",""Age"":""38"",""Json"":[{""Prop"":3}]}]";
            var table = JsonConvert.DeserializeObject<DataTable>(json, 
                new CustomDataTableConverter());
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"{row["Name"]}, {row["Age"]}, {row["Json"]}");
            }
        }
    }
    public class CustomDataTableConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => (objectType == typeof(DataTable));
        public override bool CanWrite => false;
        public override object ReadJson(JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
        {
            var rowsArray = JArray.Load(reader);
            var metaDataObj = (JObject)rowsArray.First();
            var dt = new DataTable();
            foreach (var prop in metaDataObj.Properties())
            {
                dt.Columns.Add(prop.Name);
            }
            foreach (JObject rowDataObj in rowsArray)
            {
                var row = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                {
                    if (rowDataObj[col.ColumnName].Type == JTokenType.Array)
                    {
                        row[col] = rowDataObj[col.ColumnName].ToString(Formatting.None);
                    }
                    else
                    {
                        row[col] = rowDataObj[col.ColumnName].ToObject(col.DataType);
                    }
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        public override void WriteJson(JsonWriter writer, object value, 
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
