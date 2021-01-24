    conn.Configuration.LazyLoadingEnabled = false;
    
    conn.TCODINGCATEGORies.Load();
    conn.TCODINGGROUPs.Load();
    conn.TCODINGKEYs.Load();
        
    dbCustomerList = conn.TCUSTOMERs.Include(c => c.CodingTrees.Select(t => t.CodingVDNs)).ToList();
