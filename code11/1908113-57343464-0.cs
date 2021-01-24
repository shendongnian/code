    using (var context = new dbContext())
    {
        var varOrg = context.OrganismoTransito
            .Single(b => b.Id == 1);   
     
    
        context.Entry(varOrg)
            .Reference(b => b.RadicacionesCuentaIdOrganismoTransitoDestinoNavigations)
            .Load();
    }
