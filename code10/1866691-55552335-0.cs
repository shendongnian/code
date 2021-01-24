    // not tested or compiled
    using (XmlReader reader = XmlReader.Create(file))
    {
        var cars = (CarCollection)ser.Deserialize(reader);
        
        carPool.AddRange(
           cars.Items.SelectMany(it => it.Car).Select(c => 
                new CarPool()
                {
                    Make = c.Make,
                    Model = c.Model,
                    StockNumber = c.StockNumber
                }) );
    }
