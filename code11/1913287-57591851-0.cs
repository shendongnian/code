    public static dynamic Deserialize(this string stg, Type typeWanted)
        {
             var model = Activator.CreateInstance(typeWanted);
    
            if (string.IsNullOrEmpty(stg))
                return model;
    
            model = JsonConvert.DeserializeObject(stg, typeWanted);
    
            return model;
        }
