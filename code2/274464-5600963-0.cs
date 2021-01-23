    public class BaseCar
    {
      //Basic functions for other cars to use
      void Drive();
      void Stop();
    }
    
    public class GasCar : BaseCar
    {
      // Enum is specific to a car with gas
      public Enum FuelType ....
    }
    
    public class ElectricCar : BaseCar
    {
      //No gas FueType Enum for electric car...
    }
