    public class LocationListJsonConverter : JsonConverter
    {
        public override bool CanConvert(System.Type objectType)
        {
            return objectType == typeof(LocationList);
        }
        public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
        {
            var locationList = (existingValue as LocationList) ?? new LocationList();
            var jLocationList = JObject.ReadFrom(reader);
            locationList.IsExpanded = (bool)(jLocationList["IsExpanded"] ?? false);
            var jLocations = jLocationList["_Items"];
            if(jLocations != null)
            {
                foreach(var jLocation in jLocations)
                {
                    var location = serializer.Deserialize<Location>(new JTokenReader(jLocation));
                    locationList.Add(location);
                }
            }
            return locationList;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var locationList = value as LocationList;
            JObject jLocationList = new JObject();
            if(locationList.IsExpanded)
                jLocationList.Add("IsExpanded", true);
            if(locationList.Count > 0)
            {
                var jLocations = new JArray();
                foreach(var location in locationList)
                {
                    jLocations.Add(JObject.FromObject(location, serializer));
                }
                
                jLocationList.Add("_Items", jLocations);
            }
            jLocationList.WriteTo(writer);
        }
    }
