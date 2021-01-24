    public static List<CarInfo> GetCarInfo (JObject jObject)
    {
        List<CarInfo> list = new List<CarInfo>();
        foreach (var property in jObject.Properties())
        {
            var thisProp = jObject[property.Name];
            if (thisProp.Type.ToString().Equals("Array"))
                foreach (CarInfo carInfo in JsonConvert.DeserializeObject<List<CarInfo>>(thisProp.ToString()))
                    list.Add(carInfo);
            else
                list.AddRange(GetCarInfo((JObject)jObject[property.Name]));
        }
        return list;
    }
You can use that in the main like,
    var cars = JObject.Parse(json);
    List<CarInfo> carInfos = GetCarInfo((JObject)cars["Cars"]);
    foreach(var carInfo in carInfos)
        // store in db
**Note**
I noticed that your json object doesnt really follow the same standard. Your GM has two parent companies when Honda, Toyota have one.
