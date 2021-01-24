    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer =
        new XmlSerializer(typeof(CarCollection));
            // Declare an object variable of the type to be deserialized.
            CarCollection i;
            using (Stream reader = new FileStream("cars.xml", FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                i = (CarCollection)serializer.Deserialize(reader);
            }
            // Write out the properties of the object.
           // Console.Write(
            // i.StockNumber + "\t" +
           /// i.StockNumber + "\t" +
            //i.StockNumber + "\t" +
           // i.Model + "\t" +
           // i.Make);
        }
    }
    [Serializable()]
    public partial class CarCollection
    {
        /// <remarks/>
        [XmlArrayItem("Car", IsNullable = false)]
        public Car[] Cars { get; set; }
    }
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class Car
    {
        /// <remarks/>
        public ushort StockNumber { get; set; }
        /// <remarks/>
        public string Make { get; set; }
        /// <remarks/>
        public string Model { get; set; }
    }
