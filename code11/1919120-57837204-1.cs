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
      var query = ( from car in list
                    group car by car.Make into cars
                    select new { Key = cars.Key, Count = cars.Count() } );
      var result = query.OrderByDescending(item => item.Count).FirstOrDefault();
      if (result != null) 
        MessageBox.Show(result.Key + " count = " + result.Count);
    }
