    public int LoanProductId { get; set; }
    [ForeignKey("LoanProductId")]
    public Product LoanProduct { get; set; }
    
    public int BorrowerId { get; set; }
    [ForeignKey("BorrowerId")]
    public User Borrower { get; set; }
