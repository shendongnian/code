    PersonDTO aliasDTO = null;
    q = q
        .JoinAlias(p => p.Identity, () => identityAlias)
        .SelectList(list => list
            .Select(p => p.Id).WithAlias(() => aliasDTO.Id)
            .Select(p => p.FirstName).WithAlias(() => aliasDTO.FirstName)
            .Select(p => p.LastName).WithAlias(() => aliasDTO.LastName)
            .Select(p => identityAlias.Sex).WithAlias(() => aliasDTO.Sex)
            .Select(p => identityAlias.BirthDate).WithAlias(() => aliasDTO.BirthDate))
        .TransformUsing(Transformers.AliasToBean<PersonDTO>())
        .List<PersonDTO>();
    // or
    q = q
        .JoinAlias(p => p.Identity, () => identityAlias)
        .Select(person => new PersonDto
        {
            Id = person.Id,
            FirstName = person.FirstName,
            LastName = person.LastName,
            Sex = identityAlias.Sex,
            BirthDate = identityAlias.BirthDate,
        })
        .TransformUsing(Transformers.AliasToBean<PersonDTO>())
        .List<PersonDTO>();
