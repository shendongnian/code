    public class MyApplication
    {
        public void DoWork()
        {
            string json = getJSON();
            DeviceTypeOne foo1 = new DeviceTypeOne();
            DeviceTypeTwo foo2 = new DeviceTypeTwo();
            IList<DeviceTypeOne> foo1Results = foo1.GetDeviceData(json);
            IList<DeviceTypeTwo> foo2Results = foo2.GetDeviceData(json);
        }        
    }
    // implemented GetDeviceData as extension method of DeviceBase, instead of the abstract method within DeviceBase,
    // it's slightly cleaner than the abstract method
    public static class DeviceExtensions
    {
        public static IList<T> GetDeviceData<T>(this T device, string jsonResult) where T : DeviceBase
        {
            IEnumerable<T> deviceDataList = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonResult);
            IEnumerable<T> resultList = deviceDataList.Where(x => x.Type.Equals(typeof(T).Name));
            return resultList.ToList();
        }
    }
    // abstract base class only used to house common properties and control Type assignment
    public abstract class DeviceBase : IDeviceData
    {
        protected DeviceBase(string type)
        {
            if(string.IsNullOrEmpty(type)) { throw new ArgumentNullException(nameof(type));}
            Type = type; // type's value can only be set by classes that inherit and must be set at construction time
        }
        [JsonProperty("_id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public string Type { get; private set;} 
        [JsonProperty("actions")]
        public DeviceAction[] Actions { get; set; }
    }
    public class DeviceTypeOne : DeviceBase
    {
        public DeviceTypeOne() : base(nameof(DeviceTypeOne))
        {
        }
    }
    public class DeviceTypeTwo : DeviceBase
    {
        public DeviceTypeTwo() : base(nameof(DeviceTypeTwo))
        {
        }
    }
    // renamed GetAllDevices to IDeviceData as it's really only a data container
    // also relocated nested classes outside of this class
    public interface IDeviceData
    {
        string Id { get; set; }
        string Name { get; set; }
        string Type { get; }
        DeviceAction[] Actions { get; set; }
    }
    // renamed and relocated class Action to DeviceAction
    public class DeviceAction
    {
        public string Id { get; set; }
        public DeviceActionDefinition DeviceActionDefinition { get; set; }
    }
    // renamed and relocated Action_Def to DeviceActionDefinition
    public class DeviceActionDefinition
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
