`
    public InvoiceValidator(InvoiceDetailsValidator invoiceDetailsValidator, 
                            IDbContextFactory<DbContext> dbContextFactory
                           )
`
to
`
    public InvoiceValidator(IValidator<InvoiceDetails> invoiceDetailsValidator, 
                            IDbContextFactory<DbContext> dbContextFactory
                           )
`
