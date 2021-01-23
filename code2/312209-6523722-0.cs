    public IQueryable<ICustomersAndSitesM> CustomerAndSites
    {
        get
        {
            return from customer in customerTable
                   join site in customerSitesTable
                        on customer.PLACEKEYHERE equals site.PLACEKEYHERE
                   select new CustomersAndSitesMix(customer, site);
        }
    }
