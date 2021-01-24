    public ICollection<Guid> SalesTransactionIds { get; set; } // Populate this in your Linq expression...
        
    public string DisplaySalesTransactionIds 
    {
       get { return string.Join(",", SalesTransactionIds); }
    }
