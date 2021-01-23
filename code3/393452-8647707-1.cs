        JsonConvert.DeserializeObject<NTask>(json);  
  
        public sealed class NTask
        {
            public DateTime launch_date { get; set; }
            public void SetLaunchDate(int timestamp)
            {
                // First make a System.DateTime equivalent to the UNIX Epoch.    
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                // Add the number of seconds in UNIX timestamp to be converted.    
                launch_date = dateTime.AddSeconds(timestamp);
            }
        }
