    if (panelCount < NumberOfPanelsToShow)
    {
    
      if(model.Train) {
        panelTypeList.Add(TheType.Train);
        panelCount++;
      }
    
      if (model.Car)
      {
        panelTypeList.Add(TheType.Car);
        panelCount++;
      }
      if (model.Hotel)
      {
        panelTypeList.Add(TheType.Hotel);
        panelCount++;
      }
    }
