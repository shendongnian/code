        public static DataTable DeSerializeThis(string jsString)
        {
            const string json1 = @"{""EquipmentNumber"":""CP1"",""Authgrp"":""CP01"",""Objecttype"":""9A1A""}";
            const string json2 = @"{""EquipmentNumber"":""CP2"",""Authgrp"":""CP02"",""Objecttype"":""9B1B""}";
            List<JObject> list = new List<JObject>();
            list.Add(JObject.Parse(json1));
            list.Add(JObject.Parse(json2));
            DataTable table = ToDataTable(list);
            return table;
        }
        static public DataTable ToDataTable(List<JObject> list)
        {
            DataTable dataTable = new DataTable();
            int i = 0;
            foreach (JToken content in list.ToList<JToken>())
            {
                dataTable.Rows.Add();
                foreach (JProperty prop in content)
                {
                    if (i == 0)
                    {
                        dataTable.Columns.Add(prop.Name);
                    }
                    dataTable.Rows[i][prop.Name] = prop.Value;
                }
                i++;
            }
            return dataTable;
        }
Only now is the question if this could be re-written so that the
ToDataTable(List<JObject> list)
Could be of a List<T> instead - I haven't found the answer for that...
