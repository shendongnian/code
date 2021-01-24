    public IList<Invoice> GetInvoices(string email, string language)
    {
        Using (EntityContext context = new EntityContext(ConnectionStrings.Connection))
        {
            IList<Invoice> results;
            results = context.vInvoices
                .Where(x => x.Email == email && x.Language == language)
                .Select(x => new Invoice
                {
                    DocumentNumber = x.DocumentNumber, 
                    DocumentDate = x.DocumentDate, 
                    DocumentReference = x.DocumentReference,
                    SerialNumber = x.SerialNumber, 
                    ProductCode = x.ProductCode, 
                    Description = x.Description, 
                    Certificate = x.Certificate,
                    Email = x.Email,
                    Language = x.Language
                })
                .OrderBy(x => x.DocumentDate)
                .ToList();
    
            return results;
        }
    }
    
