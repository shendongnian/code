    public class Customer
    {
        public Dictionary<string, CarBase> OwnedCars { get; set; }
    
        public void BuyCar(string manufacture)
        {
            if (manufacture== "Mercedes")
               OwnedCars[manufactor] = new Mercedes();
    
            if (manufacture== "BMW")
               OwnedCars[manufactor] = new BMW();
        }
    }
