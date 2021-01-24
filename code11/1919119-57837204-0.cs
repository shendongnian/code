    using System.Linq;
    using System.Collections.Generic;
    void TestCar()
    {
      var list = new List<Car>();
      list.Add(new Car("Audi"));
      list.Add(new Car("Volvo"));
      list.Add(new Car("Audi"));
      list.Add(new Car("BMW"));
      list.Add(new Car("Audi"));
      int count = list.Count(car => car.Make == "Audi");
      DisplayManager.Show("Audi cars count = " + count);
    }
