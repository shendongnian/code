        typeOfObject = typeOfObject.ToLower();
        if (typeOfObject == RootTypes.UAV)
        {
            stkUavObject = _stkObjectRootToIsolateForUavs.CurrentScenario.Children[stkObjectName];
            var group = (IAgDataProviderGroup) stkUavObject.DataProviders["Heading"];
            var provider = (IAgDataProvider) group.Group["Fixed"];
            IAgDrResult result = ((IAgDataPrvTimeVar) provider).ExecSingle(_stkObjectRootToIsolateForUavs.CurrentTime);
            stkObjectHeadingAndVelocity[0] = (double) result.DataSets[1].GetValues().GetValue(0);
            stkObjectHeadingAndVelocity[1] = (double) result.DataSets[4].GetValues().GetValue(0);
        }
        else if (typeOfObject == RootTypes.Entity)
        {
            IAgStkObject stkEntityObject = _stkObjectRootToIsolateForEntities.CurrentScenario.Children[stkObjectName];
            var group = (IAgDataProviderGroup) stkEntityObject.DataProviders["Heading"];
            var provider = (IAgDataProvider) group.Group["Fixed"];
            IAgDrResult result = ((IAgDataPrvTimeVar) provider).ExecSingle(_stkObjectRootToIsolateForEntities.CurrentTime);
            stkObjectHeadingAndVelocity[0] = (double) result.DataSets[1].GetValues().GetValue(0);
            stkObjectHeadingAndVelocity[1] = (double) result.DataSets[4].GetValues().GetValue(0);
        }
