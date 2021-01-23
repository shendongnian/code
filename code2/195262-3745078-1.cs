    private List<Customer> customers = new List<Customer>();
    // ^ for class-internal use only
    public IList<Customer> Customers { get { return this.customers.AsReadOnly(); } }
    //                                                            ^^^^^^^^^^^^^
    //                                                expose collection as read-only
