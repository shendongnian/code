    Mapper.Initialize(cfg =>
            {
                cfg.ValidateInlineMaps = true;
                cfg.AllowNullCollections = false;
                cfg.AllowNullDestinationValues = true;                
                cfg.DisableConstructorMapping(); // <= In the case of my project, I do not use builders, I had a performance gain.
                cfg.AddProfile<DomainToViewModelMappingProfile>();
                cfg.AddProfile<ViewModelToDomainMappingProfile>();
            });
    Mapper.AssertConfigurationIsValid();
