    public class SportsCar : ICar
    {
       public void Start() 
       {
          Console.WriteLine("Vroom Vroom. SportsCar has started");
       }
    }
    
    public class AbcCar : ICar
    {
       public void Start() 
       {
          Console.WriteLine("Chug Chug. AbcCar has started");
       }
    }
