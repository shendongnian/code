    IEnumerable<Car> cars = // however you set cars originally
    cars = cars.Select(c => new Car
                {
                    Prop1 = c.Prop1,
                    Prop2 = c.Prop2,
                    ResaleValue = ResaleCalculator(params)
                 });
