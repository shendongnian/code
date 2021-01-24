public class DeviceMap
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; } // Suggestion: Change this to 'Guid' instead of string
    [JsonProperty(PropertyName = "IPaddress")]
    public string IPaddress { get; set; }
    [JsonProperty(PropertyName = "SpeedLog")]
    public bool SpeedLog { get; set; }
    [JsonProperty(PropertyName = "LastContact")]
    public Entry LastContact { get; set; }
}
public class Entry
{
    [JsonProperty(PropertyName = "EnvLog")]
    public DateTime EnvLogtime { get; set; }
    [JsonProperty(PropertyName = "Ping")]
    public DateTime Ping { get; set; }
    [JsonProperty(PropertyName = "SpdLog")]
    public DateTime SpdLog { get; set; }
}
Your LastContact will deserialize correctly if you select `DateTime` as the type of each variable in `Entry`. 
**Testing**
I used your json and converted it to DeviceMap object to test it and make sure that above works. 
json
{
  "DataTypeId": 1,
  "IPaddress": "192.168.2.177",
  "id": "d1b81653-b7a5-4d79-85ea-79c01f43f747",
  "PhoneNo": "0417518324",
  "LastContact": {
    "EnvLog": "2019-09-07T19:41:08",
    "Ping": "2020-01-09T12:10:09",
    "SpdLog": "2019-09-07T19:41:08"
  },
  "SpeedLog": true,
  "DeviceModelId": 2,
  "DisconnectEvents": 9
}
and used the following in my main to deserialize it to make sure it works correctly.
DeviceMap map = JsonConvert.DeserializeObject<DeviceMap>(json);
[![Screenshot of Data in map.][1]][1]
It is definitely better to use the types at time of deserialization that way you wont have to parse it to the types they should be. Deserializer should take care of that for you and convert your strings to type of your class if it is convertible, like, automatically converting string to Guids or DateTime.
  [1]: https://i.stack.imgur.com/l7PDh.png
