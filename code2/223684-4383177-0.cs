    [DataContract]
    public class CarCollection {
        [DataMember]
        public int TotalCars { get { return CarList.Count; }}
        [DataMember]
        public List<Car> CarList { get; set; }
    }
    [DataContract]
    public class Car {
        [DataMember]
        public string CarName { get; set; }
        [DataMember]
        public string CarId { get; set; }
    }
