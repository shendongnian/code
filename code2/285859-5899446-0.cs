    link.Session.QueryOver<ContactAssociation>(() => ca)
                                           //.Fetch(asoc => asoc.Client)
                                           .JoinAlias(() => ca.Client, ()=> client)
    
    .Left.JoinQueryOver<BuEntry>(() => client.BuEntries, () => be)
                                           .Where(() => client.ID == clientKey)
                                           .JoinQueryOver<BuLevel>(() => be.BuLevel)
                                           .Where(bu => bu.LevelNo > buLevel);
