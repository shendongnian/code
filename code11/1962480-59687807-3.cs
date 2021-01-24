    public static Dictionary<string, List<CarInfo>> GetCarInfo (JObject jObject)
    {
        Dictionary<string, List<CarInfo>> list = new Dictionary<string, List<CarInfo>>();
        foreach (var property in jObject.Properties())
        {
            var thisProp = jObject[property.Name];
            if (thisProp.Type.ToString().Equals("Array"))
                    list.Add(property.Name, JsonConvert.DeserializeObject<List<CarInfo>>(thisProp.ToString()));
            else
                GetCarInfo((JObject)jObject[property.Name]).ToList().ForEach(x => list.Add(x.Key, x.Value));
                
            }
        return list;
    }
    public static void SaveData(string key, List<CarInfo> value)
    {
        switch (key.ToUpper())
        {
            case "CRV":
                // save it the CRV way
                break;
            case "COROLLA":
                // save it this way
                break;
            default:
                throw new ApplicationException("Unable to figure out which car it is..");
        }
    }
**Usage in Main**
    var cars = JObject.Parse(json);
    Dictionary<string, List<CarInfo>> carInfos = GetCarInfo((JObject)cars["Cars"]);
    foreach (var carInfo in carInfos)
        SaveData(carInfo.Key, carInfo.Value);
**Note**
I noticed that your json object doesnt really follow the same standard. Your GM has two parent companies when Honda, Toyota have one.
**Suggestion**
Only thing I would suggest to make the code look and perform better is to update the way you make a call to update / add to DB. Currently, you have one call per type which is what defines your foreach loops. If you can make one generic method to save "CarInfo" with another argument that defines "CRV", or "CORROLLA", it would make things Much easier for you.
