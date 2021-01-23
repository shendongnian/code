    string[] alphaOrdinals = { "A", "B", "C", "D", "E" };
    var query = dataContext.Cars
                           .AsEnumerable()
                           .Select((car, index) => new InventoryItem { 
                                      Name = car.Name,
                                      Price = car.Price,
                                      UIElement = string.Format("Car {0} {1}",
                                                                car.Id,
                                                                alphaOrdinals[index])
                                   }).ToList();
