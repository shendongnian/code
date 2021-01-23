    [XmlRoot("Hotels")]
    public class HotelResult // or something similar
    {
        [XmlElement("Hotel")]
        public List<HotelBasic> Hotels { get { return hotel; } }
        private readonly List<HotelBasic> hotels = new List<HotelBasic>();
    }
