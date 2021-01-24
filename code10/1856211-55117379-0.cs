    public decimal AmountOfRent { get; set; }
    
    public decimal AmountPaid { get; set; }
    
    public decimal RemainingAmount => AmountOfRent - AmountPaid;
