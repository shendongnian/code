    // private field for your data
    private List<InvoiceLine> _lines = new List<InvoiceLine>();
    
    // public prop to expose it - but I'd be better still if I just exposed an Add method.
    public List<InvoiceLine> Lines
    {
      get { return this._lines; }
    }
