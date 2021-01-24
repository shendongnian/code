    public class Tags
    {
        [JsonProperty("tiger:maxspeed")]
        public string Maxspeed { get; set; }
        [JsonIgnore]
        public int MaxSpeedInt => int.Parse(Maxspeed.Split(' ')[0]);
    }
