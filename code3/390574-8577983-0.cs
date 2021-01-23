    [DataContract]
    public class Geo
    {
        [DataMember(Name = "coordinates")]
        public double[] Coordinates { get; set; }
    }
