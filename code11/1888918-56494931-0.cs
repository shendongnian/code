    using (var entity = new AutomobileEntity())
    {
        return (from details in entity.dbVechiles.Where(i => i.IsActive == true)
                   join sp in entity.dbSpeed.Where(i => i.IsActive) on details.vspeed equals sp.vspeed
                   select new Automobile
                   {
                       Vid = details.vId,
                       VName = details.vName,
                       Vspeed = sp.vspeed,
                       VRate = sp.vrate
                   }).OrderBy(x => x.VName).ThenByDescending(x => x.Vid).ToList();
    }
