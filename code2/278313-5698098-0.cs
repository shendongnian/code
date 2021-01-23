    public class PlainOldCar : ICar
    {
      public string A {get;set;}
      public PlainOldCar(ICar carSource) //copy constructor
      {
        this.A = carSource.A;
      }
    }
