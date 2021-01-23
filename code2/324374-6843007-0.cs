    [PersistenceMode(PersistenceMode.Attribute)]
    [Bindable(BindableSupport.Yes)]
    public long? InvoiceID 
    {
       get { 
             return (long?)_InvoiceIDHiddenn.Value; 
           } 
       set {
              _InvoiceIDHiddenn.Value = value; 
           } 
    }
