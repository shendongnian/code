    public class CarsRequest
    {
      public int DealershipId { get; set; }
      public int RequesterId { get; set; }
    }
    
    public class CarsResponse
    {
      public Car[] Cars { get; set; }
    }
    
    CarsResponse GetCarsRelatedToDealership(CarsRequest request);
