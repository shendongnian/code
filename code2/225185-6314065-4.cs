    public CarEngine(FuelInjectors injectors, DrivingAssistComputer computer) {
      this.injectors = injectors;
      // This ofcourse could also be moved to CarEngine.Initialse
      computer.Initialise(); 
    }
    
    ...
