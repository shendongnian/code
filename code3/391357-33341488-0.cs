        var credentials = new ClientCredentials();
        credentials.Windows.ClientCredential = new System.Net.NetworkCredential(userName, password, domain);
        var proxy = new OrganizationServiceProxy(new Uri(discoveryUrl), null, credentials, null);
        proxy.EnableProxyTypes(typeof(CrmServiceContext).Assembly);
        return new CrmServiceContext(proxy);
    }
