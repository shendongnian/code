     List<Car> cars = new List<Car>();
     //populate cars
     var carGroups = cars.Select((car, index) => new { Index = index, Car = car })
                            .GroupBy(x => x.Index / 5)
                            .Select(g => g.Select(x => x.Car).ToList())
                            .ToList();
        foreach (var group in carGroups)
        {
            //Emit <UL>
            foreach (var car in group)
            {
                //Emit <LI> with car details
            }
            //Emit </UL>
        }
