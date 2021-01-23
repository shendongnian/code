        static ResultArray ConvertJson(string json)
        {
            ResultArray fromJson;
            JavaScriptSerializer jSer = new JavaScriptSerializer();
            try
            {
                fromJson = jSer.Deserialize<ResultArray>(json);
                return fromJson;
            }
            catch (InvalidOperationException)
            {
                var single = jSer.Deserialize<ResultSingle> (json);
                fromJson = new ResultArray();
                fromJson.Data = new List<DataClass>();
                fromJson.Data.Add(single.Data);
                return fromJson;
            }
        }
        static void Main(string[] args)
        {
            var jsonWithSingleInstance = "{\"Data\":{\"FirstName\":\"Knud\",\"BirthYear\":1928}}";
            var jsonWithArray = "{\"Data\":[{\"FirstName\":\"Knud\",\"BirthYear\":1928},{\"FirstName\":\"Svend\",\"BirthYear\":1930}]}";
            var single = ConvertJson(jsonWithSingleInstance);
            var array = ConvertJson(jsonWithArray);
        }
