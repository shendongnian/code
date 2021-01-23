        // not good design
    public ActionResult Create(AnimalInput input)
    {
         Animal animal = new Animal { Name = input.Name}; // set the other propreties
        // if you have a CRUD operations in service class you will call
        animalService.UpdateOrInsert(animal);
         
    }
    // better disign
    public ActionResult Create(AnimalInput input)
    {
        
        animalService.Create(input.Name);
         
    }
