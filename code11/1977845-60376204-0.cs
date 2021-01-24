    var car = _context.Cars.Where(...).FirstOrDefault();
    if (car == null)
    {
        var entity = _context.Cars.Add(new Car
        {
           ...
        });
    }
    
    var serviceOrder = _context.Add(new ServiceOrder
    {
       Client = client,
       Car = car, // <-- 'car' is still null when you assign it's value to the service order
       ...
    }
