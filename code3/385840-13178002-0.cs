    [Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute("prioritycode")]
    public Microsoft.Xrm.Sdk.OptionSetValue PriorityCode
    {
    	get
    	{
    		return this.GetAttributeValue<Microsoft.Xrm.Sdk.OptionSetValue>("prioritycode");
    	}
    	set
    	{
    		this.OnPropertyChanging("PriorityCode");
    		this.SetAttributeValue("prioritycode", value);
    		this.OnPropertyChanged("PriorityCode");
    	}
    }
