    XmlSerializer ser = new XmlSerializer(typeof(CarCollection));
    
    CarCollection cars = null;
    
    using (StreamReader reader = new StreamReader(@"Path to your xml file"))
    {
        cars = (CarCollection)ser.Deserialize(reader);
        reader.Close();
    }
    
    List<Car> result = cars.Cars.Car.ToList();
    
    //--------------------------Print the result to console--------------
    Console.WriteLine("StockNumber\tMake\t\tModel");
    Console.WriteLine("----------------------------------------------");
    foreach (var item in result)
    {
        Console.WriteLine(item.StockNumber + "\t\t" + item.Make + "\t\t" + item.Model); ;
    }
    
    Console.ReadLine();
