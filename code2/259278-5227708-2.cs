    public class Camera
    {
        public Camera()
        {
            Configuration1 = new Configuration1();
            Configuration2 = new Configuration2();
        }
        private object configuration;
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public object Configuration { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Configuration1 Configuration1 { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Configuration2 Configuration2 { get; set; }
    }
