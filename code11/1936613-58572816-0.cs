    public static async Task<IEnumerable<Account>> ExecuteCustomersQueryAsync()
        {
            OrgContext crm = new OrgContext(new Uri("http://<Server>/<Org>/XRMServices/2011/OrganizationData.svc/"));
            crm.Credentials = new NetworkCredential("Username", "Password", "Domain");
            DataServiceQuery<Account> query = crm.AccountSet
                .AddQueryOption("$filter", "new_Class/Value eq 100000000");
            try
            {
                (ODataStandartResponse, IEnumerable<Account>) rez =  await query.ExecuteAsync();
                return rez.Item2;
            }
            catch (DataServiceQueryException ex)
            {
                throw new ApplicationException(
                    "An error occurred during query execution.", ex);
            }
        }
