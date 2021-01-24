    IList<IEntitaAssociabile> result = praticheAperteNonAssegnate
      .AsParallel()
      .Select(pratica => new EntitaAssociabile() {
         Id = pratica.ID_Prat,
         ...
       })
      .OrderBy(item => item.Id)
      .ToList();
