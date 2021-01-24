    IQueryable<Car> cars = from ld in _context.Car.Where(c => mat.Contains(c.RefNumber))
                                                 select new Car
                                                 {
                                                     RefNumber = ld.RefNumber
                                                };
                Car [] ExistingCars = cars.ToArray();
