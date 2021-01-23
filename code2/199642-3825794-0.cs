    public static ArrayList EnumerateDomainControllers()
    {
        ArrayList alDcs = new ArrayList();
        Domain domain = Domain.GetCurrentDomain();
        foreach (DomainController dc in domain.DomainControllers)
        {
            alDcs.Add(dc.Name);
        }
        return alDcs;
    }
