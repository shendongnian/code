    static void Main(string[] args)
    {
      Car c1 = new Car("Toyota", "Model", "1");
      Console.WriteLine(c1.engine.engineNumber);
    }
    public class Car
    {
      public class Engine
      {
        public string engineNumber;
        internal protected Engine(string engineNumber)
        {
          this.engineNumber = engineNumber;
        }
      }
      public string name { get; private set; }
      public string model { get; private set; }
      public Engine engine { get; private set; }
      public Car(string name, string model, string engineNumber)
      {
        this.name = name;
        this.model = model;
        this.engine = new Engine(engineNumber);
      }
    }
