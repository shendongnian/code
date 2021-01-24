    public class Athlete
    {
        private string rightOrLeftFoot;
        [JsonProperty(Required = Required.Always)]
        public string AthleteType { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string RightOrLeftFood { 
            get { return rightOrLeftFoot; } 
            set 
            {
                if (AthleteType.Equals("SOCCER") && string.IsNullOrEmpty(value))
                    throw new ApplicationException("value is required for RightOrLeftFood when AthleteType is SOCCER");
                rightOrLeftFoot = value;
            } 
        }
    }
When I work with getters and setters, i like to use a local variable. In the setter, you can check whether the AthleteType is defined as SoccerPlayer or whatever you are interested in comparing, then go about the deserialization. 
Athlete athlete = JsonConvert.DeserializeObject<Athlete>(json);
Exception will be thrown ONLY if the attribute `AthleteType` is "SOCCER" and value for `RightOrLeftFoot` is null / empty string.
