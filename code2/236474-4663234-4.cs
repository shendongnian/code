    if (typeOfObject == "UAV")
    {
    	DoSomeWork(_stkObjectRootToIsolateForUavs);
    }
    else if (typeOfObject == "Entity")
    {
    	DoSomeWork(_stkObjectRootToIsolateForEntities);
    }
    
    private void DoSomeWork(IAgStkObject agStkObject)
    {
        IAgStkObject stkObject = agStkObject.CurrentScenario.Children[stkObjectName];
    	IAgDataProviderGroup group = (IAgDataProviderGroup)stkUavObject.DataProviders["Heading"];
    	IAgDataProvider provider = (IAgDataProvider)group.Group["Fixed"];
    	IAgDrResult result = ((IAgDataPrvTimeVar)provider).ExecSingle(_stkObjectRootToIsolateForUavs.CurrentTime);
    
    	stkObjectHeadingAndVelocity[0] = (double)result.DataSets[1].GetValues().GetValue(0);
    	stkObjectHeadingAndVelocity[1] = (double)result.DataSets[4].GetValues().GetValue(0);
    }
