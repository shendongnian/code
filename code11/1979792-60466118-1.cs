    public class Class1
    {
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
        public Temp Temp { get; set; }
        public Pressure Pressure { get; set; }
        public Humidity Humidity { get; set; }
    }
    public class Temp
    {
        public int value { get; set; }
    }
    public class Pressure
    {
        public int value { get; set; }
    }
    public class Humidity
    {
        public int value { get; set; }
    }
