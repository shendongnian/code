    public class MyModel
    {
        public string Letters { get; set; }
        public int Numbers { get; set; }
        public string Section
        {
            get
            {
                return $"{Letters}{Numbers}";
            }
        }
    }
