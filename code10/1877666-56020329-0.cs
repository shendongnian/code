    var cars = new List<Car>();
            var drivers = new List<Driver>();
            var taksi = from c in cars
                        from d in drivers
                        where c.RegPlate == d.RegPlate
                        select new Taksi()
                        {
                            Name = d.Name,
                            RegPlate = d.RegPlate,
                            Trademark = c.Trademark,
                            YearMade = c.YearMade,
                            Mileage = c.Mileage
                        };
