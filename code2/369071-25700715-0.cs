        private static T CloneObject<T>(T obj)
        {
            if (obj == null)
                return obj;
            string ser = JsonConvert.SerializeObject(obj, Formatting.Indented, 
                new JsonSerializerSettings() {
                                    NullValueHandling = NullValueHandling.Ignore,
                                    MissingMemberHandling = MissingMemberHandling.Ignore,
                                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
            return (T) JsonConvert.DeserializeObject(ser, obj.GetType());
        }
