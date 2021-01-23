    ...
    asyncOpResult = DGGroup.BeginExpand(ExpandCallback, DGGroup);
    ...
    
    public void ExpandCallback(IAsyncResult ar)
    {
        DistributionGroup DGGroup = (DistributionGroup)ar.AsyncState;
        DGGroup.EndExpand(ar);
        etc...
    }
