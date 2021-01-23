    public class Car
    {
      public static Car firstCar;
      public Car()
      {
        if (firstCar == null)
          firstCar = this;
      }
      public string Brand {get; set;}
      public static Car GetFirstCarEverBuild()
      {
        return firstCar;
      }
    }
