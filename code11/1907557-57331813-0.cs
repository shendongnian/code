    public abstract class HomeDevices<T> where T: GetAllDevices
    {
        public HomeDevices(string concreteType)
        {
            type = concreteType;
        }
        public string type { get; set; }
        public string _id { get; set; }
        public List<Thermostat> Thermostats { get; set; }
        public List<Alexa> Alexas { get; set; }
        //This method is now generic and works for both.
        public List<T> GetDeviceData(string jsonResult)
        {
            var lst = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(jsonResult);
            var lst1 = lst.Where(x => x.Type.Equals(type)).ToList();
            return lst1;
        }
    }
