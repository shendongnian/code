    [Serializable]
    public class Configuration : ICloneable
    {
        public Configuration()
        {
            a = "a";
            b= "b"
        }
        public string a { get; set; }
        public string b { get; set; }
        
        public object Clone()
        {
            return new Configuration
            {
                a = a,
                b= b
            };
        }
    }
