    public bool FilterByBusinessTypeID(dc.Business dcBusiness)
    {
       return dcBusiness.ID == anIdVariable;
    }
    var result= BusinessType.Where(FilterByBusinessTypeID).First(); 
