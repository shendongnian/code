    // allocate projects
    ProjectAllocation projAlloc = salJourn.AllocateLine(2);
    projAlloc.SetProject("Sage Project", 1);
    try
    {
       projAlloc.SetPercent(50.0, 1);
    }
    catch (SimplyNoAccessException)
    {
       // can't allocate by percent, allocation by amount
       projAlloc.SetAmount(0.99, 1);
    }
    projAlloc.Save();
