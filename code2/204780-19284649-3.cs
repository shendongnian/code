    public class LaneConfigElement : ConfigurationElement
        {
            [ConfigurationProperty("Id")]
            public string Id
            {
                get
                {
                    return base["Id"] as string;
                }
            }
    
            [ConfigurationProperty("PointId")]
            public string PointId
            {
                get
                {
                    return base["PointId"] as string;
                }
            }
    
            [ConfigurationProperty("Direction")]
            public Direction? Direction
            {
                get
                {
                    return base["Direction"] as Direction?;
                }
            }
        }
    
        public enum Direction
        { 
            Entry,
            Exit
        }
