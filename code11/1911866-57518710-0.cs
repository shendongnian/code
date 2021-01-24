    public ShippingCont(string id)
    {
        this._existingContainerId = id;
        sc2 = shippingContainer.SHIPPING_CONTAINERs.FirstOrDefault(a => a.CONTAINER_ID == _externalContainerId);
    }    
    public static ShippingContainerDataContext shippingContainer = new ShippingContainerDataContext();
    public SHIPPING_CONTAINER sc2;
    private string _containerId = sc2.COMPANY;
    private string _company = sc2.COMPANY;
    public string fromProgram
    {
        get { return _externalContainerId; }
    }
    public string ContId
    {
        get { return sc2.CONTAINER_ID; }
        set { _externalContainerId = value; }
    }
    public string _ContainerId
    {
        get { return sc2.CONTAINER_ID; }
        set { _ContainerId = value; }
    }
    public string _Company
    {
        get { return sc2.COMPANY; }
        set { _company = value; }
    }
