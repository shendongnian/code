    public IEnumerable<InvoiceHeader> Getdata(Expression<Func<InvoiceHeader, bool>> predicate)
    {
        return AccountsContext.InvoiceHeaders.Include("Company").Include("Currency")
            .Include("BusinessPartnerRoleList").Include("DocumentType")
            .AsEnumerable()
            .Where(predicate);
    }
