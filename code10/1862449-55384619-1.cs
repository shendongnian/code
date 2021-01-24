    BaseClass Genetic
    void Start()
    {
      if (RaceSelect.SelectedRace == 2)
      {
        Genetic = geneticDriver;
      } else
      {
        Genetic = geneticController;
      }
    }
    void FixedUpdate()
    {
      float steer = Genetic.Steering;
      Steering(steer);     
    }
