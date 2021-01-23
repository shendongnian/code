    private List<EventType> _eventTypes;
    public ManageProfileModel()
    {
        _referenceData = new ReferenceDataContext();
        
        var op = _referenceData.Load(_referenceData.GetEventTypesQuery(), false);
        op.Completed += op_Completed;
        
    }
    
    void po_Completed(object sender, EventArgs e)
    {
        var op = ( InvokeOperation<IEnumerable<EventType>>)sender;
        _eventTypes = op.Value.ToList();
    }
