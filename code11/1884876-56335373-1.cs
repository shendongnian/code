    foreach(var n in animalbirdAdoptionDetails)
    {
        // remove unwanted variables and casting expression.
        // if not required then.
        int animalBirdsId = n.AnimalsAndBirdsId;
        int NoAnimal =  Convert.ToInt32(n.NoAnimalsAdopted);
        n.isActive = false;
        // Retrieve existing record
        var entity = context.NameOfAnimalsAndBirds.FirstOrDefault(x => x.Id == n.Id);
        // assign new value to existing property.
        entity.quantity = entity.quantity + moreQuantity;
        // in last just apply save changes.
        context.SaveChanges();
    }
