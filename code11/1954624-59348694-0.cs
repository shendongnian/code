    var obj = JObject.Parse(jsonDoc);
    var something = JsonConvert.DeserializeObject<AllObjects>(obj["0"].ToString());
and your classes would look like this (I know you can name them better :) )
    public class ObjInfo
    {
        public int cost { get; set; }
        public int count { get; set; }
    }
    public class AllObjects
    {
        public ObjInfo vk { get; set; }
        public ObjInfo ok { get; set; }
        public ObjInfo wa { get; set; }
    }
                        
Reason you might have to do the way i did above is because you cannot have a variable with number... like ```public AllObjects 0 {get;set;}```, but, you CAN do the following
    public class MainObj
    {
        [JsonProperty("0")]
        public AllObjects Zero { get; set; }
    }
using the following line would deserialize correctly.
    var something2 = JsonConvert.DeserializeObject<MainObj>(jsonDoc);
    // where jsonDoc is your actual string input.
