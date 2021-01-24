    entities.Truck.Attach(Truck); // if it already exists.
    // since you are loading it again for some reason
    var ObjectModel = entities.Truck.Where(x => x.Code == Truck.Code && x.CodePlant == Truck.CodePlant).FirstOrDefault();
    // Mapping Modified Properties
    ObjectModel = Mapper.Map(updateInfo, ObjectModel); // this looks dubious
    // You've just loaded it from the context so it's tracked, so you could just save it
    entities.SaveChanges();
