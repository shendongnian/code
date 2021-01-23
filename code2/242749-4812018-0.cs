    public abstract class PremiseObject
    {
        protected PremiseObject()
        {
        }
        public string Location { get; set; }
        public static void GetSensor<T>(string location, out T sensor)
                 where T : PremiseObject, new()
        {
            PremiseObject so;
            if(_locationSingltons.TryGetValue(location, out so))
            {
                sensor = (T) so; // this will throw and exception if the 
                // wrong type has been created. 
                return;
            }
            sensor = new T();
            sensor.Location = location;
            _locationSingltons.Add(location, sensor);
        }
        private static Dictionary<string, PremiseObject> _locationSingltons 
                 = new Dictionary<string, PremiseObject>();
    }
