      // if it does not know that variable try making a method instead that compares to the 
     //anIdVariable will something like this work it's the same thing as the Linq but in more of a Method format just as an example
    public bool FilterByBusinessTypeID(dc.Business dcBusiness)
    {
       return dcBusiness.ID == anIdVariable;
    }
    var result= BusinessType.Where(FilterByBusinessTypeID).First(); 
