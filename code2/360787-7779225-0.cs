        public class Car
        {
          public int CarID { get; set; }
          public string CarName { get; set; }
          public CarType CarType { get; set; }
          public Make CarMake { get; set; }
          // Expose CarTypeName as first-level property
          public string CarTypeName { get {return CarType.CarTypeName; }}
        }
        public class CarType
        {
          public int CarTypeID { get; set; }
          public string CarTypeName { get; set; }
        }
