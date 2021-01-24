    public class Tags
    {
        [JsonIgnore]
        public int MaxSpeed { get; set; }
    
        [JsonProperty("tiger:maxspeed")]
        private string MaxSpeedString
        {
            get { return MaxSpeed + " mph"; }
            set 
            {
                if (value != null && int.TryParse(value.Split(' ')[0], out int speed))
                    MaxSpeed = speed;
                else
                    MaxSpeed = 0;
            }
        }
    }
