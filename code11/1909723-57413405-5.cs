    public class ValidationBase
    {
        public string ValidateObject(string json, object obj)
        {
            var dictJSON = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var listParameterInJSON = dictJSON.Keys.ToHashSet<string>();
            listParameterInJSON.ToList().ForEach(x => x = x.ToLower());
            var jsonObj = JsonConvert.SerializeObject(obj);
            var dictObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonObj);
            var listParameterInObj = dictObj.Keys.ToList();
            listParameterInObj = listParameterInObj.ConvertAll(d => d.ToLower());
            listParameterInObj.ToHashSet<string>();
            var fields = listParameterInJSON.Except(listParameterInObj);
            if (fields.ToList().Count == 0) return "";
            var result = "Didn't expect property ";
            foreach (var item in fields)
            {
                result += "'" + item + "'" + " ";
            }
            return result;
        }
    }
