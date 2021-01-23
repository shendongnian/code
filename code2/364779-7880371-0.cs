    // Or use arrays...
    List<Cat> cats = new List<Cat>();
    cats.Add(new Cat(...)); // Add the cats however you want to set them up
    // Ditto dogs, goats etc
    List<BackyardObject> backyardObjects = new List<BackyardObject>();
    for (int i = 0; i < 10; i++)
    {
        backyardObjects.Add(new BackyardObject(cats[i], dogs[i],
                                               goats[i], piglets[i]));
    }
