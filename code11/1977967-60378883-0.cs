public class SensorModel
{
    [JsonProperty("sensorId")]
    public string SensorId { get; set; }
    [JsonProperty("data_in")]
    public Dictionary<string,string> Inbounddata { get; set; }
    [JsonProperty("ts")]
    public DateTime Ts { get; set; }
}
For example,
var sensorModel = new SensorModel
{
	SensorId = "2",
	Ts = DateTime.Now,
	Inbounddata = new Dictionary<string,string>
	{
		["temp"] = "22.5",
		["batt"] = "3.11",
		["ss"] = "22"
	}
		
};
	
var result = JsonConvert.SerializeObject(sensorModel);
Output
{"sensorId":"2","data_in":{"temp":"22.5","batt":"3.11","ss":"22"},"ts":"2020-02-24T20:46:39.9728582+05:30"}
