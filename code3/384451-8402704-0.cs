    public void PopulateStateInfo()
    {
        StatesAndTerritories states = new StatesAndTerritories();
    
        foreach (State state in states.GetStates())
        {
            stateInfoBox.Items.Add(state);
        }
    }
