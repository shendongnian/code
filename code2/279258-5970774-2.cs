    .Mappings(m => {
        var persistenceModel = new PersistenceModel();
        persistenceModel.AddMappingsFromAssembly(typeof(Category).Assembly);
        persistenceModel.ValidationEnabled = false; // this makes the trick
        m.UsePersistenceModel(persistenceModel);
    })
