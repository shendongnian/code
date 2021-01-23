    public AddIfSpace(bool thingToTest, TheType typeToAdd, ref currentCount)
    {
        if (currentCount<NumberOfPanelsToShow && thingToTest)
        {
         panelTypeList.Add(typeToAdd);
         currentCount++;
        }
    }
