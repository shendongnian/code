    using System.Globalization;
    public class Coordinate
    {
      NumberFormatInfo nfi = new NumberFormatInfo();
      nfi.NumberDecimalSeparator = ".";
      public Coordinate()
      {
      }
      public int ID { get; set; }
      public double Latitude
      {
        get
        {
            return this.Latitude.ToString(nfi);
        }
        set
        {
            this.Latitude = value;
        }
      }
      public double Longitude
      {
        get
        {
            return this.Longitude.ToString(nfi);
        }
        set
        {
            this.Longitude = value;
        }
      }
      public int MeasurementId { get; set; }
    }
