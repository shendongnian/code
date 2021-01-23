    public class DataController
    {
       public IEnumerable<Car> GetCars(int param1, int param2)
       {
          return this.DataModel.Cars;
       }
    }
