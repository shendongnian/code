     CarEngine CreateEngine(FuelInjectors injectors) {
      new DrivingAssistComputer().Initialise(); 
      return new CarEngine(injectors);
    }
    
    ...
