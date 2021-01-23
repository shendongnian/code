    IModule<Giraffe> gm = GetMeAModuleOfGiraffes();
    IModule<Animal> am = gm; // Legal because of covariance.
    IEnumerable<Tiger> tigers = GetMeASequenceOfTigers();
    IEnumerable<Animal> animals = tigers; // Legal because of covariance.
    am.Import(animals); // Uh oh.
