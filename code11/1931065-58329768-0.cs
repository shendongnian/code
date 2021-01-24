    using System;
					
    public class Program
    {
	  public static void Main()
	  {
		var c = new Car("Name", "Model", "Engine");
		Console.WriteLine(c.engine.engineNumber);
	  }
	
      class Car
      {
        string name;
        string model;
	    public Engine engine;
        public Car(string name, string model, string engineNumber)
        {
          this.name = name;
          this.model = model;
          this.engine = new Engine(engineNumber);
        }
      }
	
      class Engine
      {
        public string engineNumber;
        public Engine(string engineNumber)
        {
          this.engineNumber = engineNumber;
        }
      }	
    }
