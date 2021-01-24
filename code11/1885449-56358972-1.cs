    using System.Globalization;
    public class Coordinate
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
        public Coordinate()
        {
            nfi.NumberDecimalSeparator = ".";
        }
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int MeasurementId { get; set; }
        public string GetLatitudeComma()
        {
            return this.Latitude.ToString(nfi);
        }
        public string GetLongitudeComma()
        {
            return this.Longitude.ToString(nfi);
        }
    }
