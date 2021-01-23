    public static T GetSensor<T>(string location) where T : PremiseObject, new()
    {
        PremiseObject so;
        if (_locationSingltons.TryGetValue(location, out so))
        {
            return (T)so; // this will throw and exception if the 
            // wrong type has been created. 
            
        }
        T result = new T();
        result.Location = location;
        _locationSingltons.Add(location, result);
        return result;
    }
 
