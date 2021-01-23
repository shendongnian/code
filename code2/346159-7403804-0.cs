       public class Place
        {
    
            public string ID { get; set; }
            public string Name { get; set; }
            public float Latitude { get; set; }
            public float Longitude { get; set; }
            
        }
    private void Run()
    {
        List<Place> places = new List<Place>();
        JObject jObject = JObject.Parse(json);
        foreach (var item in jObject)
        {
            JToken jPlace = jObject[item.Key];
            float latitude = (float)jPlace["Latitude"];
            float longitude = (float)jPlace["Longitude"];
            string name = (string)jPlace["Name"];
            places.Add(new Place { ID = item.Key, Name = name, Latitude = latitude, Longitude = longitude });
        }
    }
