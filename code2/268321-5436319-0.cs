    List<TemperatureInfo> infos = new List<TemperatureInfo>()
    {
        new TemperatureInfo("Probe")
        {
    	new Temperature("P33352", "Temperature 1"),
    	new Temperature("P33353", "Temperature 2"),
        },
        new TemperatureInfo("Rack")
        {
    	new Temperature("P33384", "Temperature 1"),
    	new Temperature("P33385", "Temperature 2"),
        }
    };
    
    public class TemperatureInfo : List<Temperature>
    {
        public string Name { get; set; }
    
        public TemperatureInfo(string name)
        {
    	this.Name = name;
        }
    }
    
    public class Temperature
    {
        public string ID { get; set; }
        public string Label { get; set; }
    
        public Temperature(string id, string label)
        {
    	this.ID = id;
    	this.Label = label;
        }
    }
