    IEnumerable<State> GetListOfStates(string[] stateNames, int[] statePopulations)
    {
        return stateNames.Zip(statePopulations, 
                              (name, population) => new State()
                              {
                                  Name = name,
                                  Population = population
                              });
    }
